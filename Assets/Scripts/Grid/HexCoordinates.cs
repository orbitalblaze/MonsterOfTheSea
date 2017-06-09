using UnityEngine;

[System.Serializable]
public struct HexCoordinates {

    [SerializeField]
    private int x, z;

    public int X {
        get {
            return x;
        }
    }
    
    public int Y {
        get {
            return -X - Z;
        }
    }

    public int Z {
        get {
            return z;
        }
    }

    public HexCoordinates (int x, int z) {
        this.x = x;
        this.z = z;
    }

    public static HexCoordinates FromOffsetCoordinates (int x, int z) {
        return new HexCoordinates(x - z / 2, z);
    }

    

    public override string ToString () {
        return "(" +
               X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
    }

    public string ToStringOnSeparateLines () {
        return X.ToString() + "\n" + Y.ToString() + "\n" + Z.ToString();
    }

    public static HexCoordinates FromPosition (Vector3 position)
    {
       
        float x = position.x / (HexMetrics.innerRadius * 2f);
        float z = -x;
        float offset = position.y / (HexMetrics.outerRadius * 3f);
        x -= offset;
        z -= offset;
        int iX = Mathf.RoundToInt(x);
        int iZ = Mathf.RoundToInt(z);
        int iY = Mathf.RoundToInt(-x -z);
        if (iX + iZ + iY != 0)
        {
            float dX = Mathf.Abs(x - iX);
            float dY = Mathf.Abs(z - iZ);
            float dZ = Mathf.Abs(-x - z - iY);

            if (dX > dY && dX > dZ)
            {
                iX = -iZ - iY;
            }
            else if (dY > dZ)
            {
                iZ = -iX - iZ;
            }
        }
        return new HexCoordinates(iX, iY);
    }

}