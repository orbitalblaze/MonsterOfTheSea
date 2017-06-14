using UnityEngine;
namespace Grid
{
    public class Cell : MonoBehaviour
    {
        public GridPosition position;
        
        public bool inNeighborhood(int clickedX, int clickedY)
        {
            if (position.x % 2 == 0)
            {
                Vector2[] evenDir = new Vector2[6];
                evenDir[0] = new Vector2(0f, -1f);
                evenDir[1] = new Vector2(1f, 0f);
                evenDir[2] = new Vector2(1f, 1f);
                evenDir[3] = new Vector2(0f, 1f);
                evenDir[4] = new Vector2(-1f, 1f);
                evenDir[5] = new Vector2(-1f, 0f);
                for (int i = 0; i < evenDir.Length; i++)
                {
                    if((position.x == (clickedX + evenDir[i].x)) && (position.y == (clickedY + evenDir[i].y)))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                Vector2[] oddDir = new Vector2[6];
                oddDir[0] = new Vector2(0f, -1f);
                oddDir[1] = new Vector2(1f, -1f);
                oddDir[2] = new Vector2(1f, 0f);
                oddDir[3] = new Vector2(0f, 1f);
                oddDir[4] = new Vector2(-1f, 0f);
                oddDir[5] = new Vector2(-1f, -1f);
                for (int i = 0; i < oddDir.Length; i++)
                {
                    if((position.x == (clickedX + oddDir[i].x)) && (position.y == (clickedY + oddDir[i].y)))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private void Awake()
        {
            position = new GridPosition();
        }

        public void userClick()
        {
            print(position.x + ", " + position.y);
            GetComponentInParent<Board>().newSelectedCell(this);
        }

        public bool hasToken()
        {
            if (GetComponentInChildren<Token>() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Token getToken()
        {
            return GetComponentInChildren<Token>();
        }

    }
}