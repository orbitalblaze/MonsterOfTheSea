﻿using UnityEngine;

[System.Serializable]
public struct HexCoordinates {

    [SerializeField]
    private int x, z;

    public int X {
        get {
            return x;
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

    public static HexCoordinates FromOffsetCoordinates (int x, int y) {
        return new HexCoordinates(x - y / 2, y);
    }

    public int Y {
        get {
            return -X - Z;
        }
    }

    public override string ToString () {
        return "(" +
               X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
    }

    public string ToStringOnSeparateLines () {
        return X.ToString() + "\n" + Y.ToString() + "\n" + Z.ToString();
    }


}