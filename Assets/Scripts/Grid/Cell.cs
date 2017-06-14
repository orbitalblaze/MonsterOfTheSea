using System.Collections.Generic;
using UnityEngine;
namespace Grid
{
    public class Cell : MonoBehaviour
    {
        public GridPosition position;
        
        
        public bool isNeighbor(GridPosition clickedCellPos)
        {
            if (position.x % 2 == 0)
            {
                Vector2[] evenDir = new Vector2[6];
                evenDir[0] = new Vector2(0f, -1f);
                evenDir[1] = new Vector2(1f, 0f);
                evenDir[2] = new Vector2(1f, -1f);
                evenDir[3] = new Vector2(0f, 1f);
                evenDir[4] = new Vector2(-1f, -1f);
                evenDir[5] = new Vector2(-1f, 0f);
                for (int i = 0; i < 6; i++)
                {
                    print(position.x + " |||X||| " + (clickedCellPos.x + evenDir[i].x));
                    print(position.y + " |||Y||| " + (clickedCellPos.y + evenDir[i].y));
                   
                    if((clickedCellPos.x == (position.x + evenDir[i].x)) && (clickedCellPos.y == (position.y + evenDir[i].y)))
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
                oddDir[1] = new Vector2(1f, 1f);
                oddDir[2] = new Vector2(1f, 0f);
                oddDir[3] = new Vector2(0f, 1f);
                oddDir[4] = new Vector2(-1f, 0f);
                oddDir[5] = new Vector2(-1f, 1f);
                for (int i = 0; i < 6; i++)
                {
                    if((clickedCellPos.x == (position.x + oddDir[i].x)) && (clickedCellPos.y == (position.y + oddDir[i].y)))
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

        public List<Cell> getNeighbors()
        {
            List<Cell> neighbors = new List<Cell>();

           
            Vector2[] neighborsDirections = new Vector2[6];
            
            if (position.x % 2 == 0)
            {
                neighborsDirections[0] = new Vector2(0f, -1f);
                neighborsDirections[1] = new Vector2(1f, 0f);
                neighborsDirections[2] = new Vector2(1f, -1f);
                neighborsDirections[3] = new Vector2(0f, 1f);
                neighborsDirections[4] = new Vector2(-1f, -1f);
                neighborsDirections[5] = new Vector2(-1f, 0f);
               
            }
            else
            {
                neighborsDirections[0] = new Vector2(0f, -1f);
                neighborsDirections[1] = new Vector2(1f, 1f);
                neighborsDirections[2] = new Vector2(1f, 0f);
                neighborsDirections[3] = new Vector2(0f, 1f);
                neighborsDirections[4] = new Vector2(-1f, 0f);
                neighborsDirections[5] = new Vector2(-1f, 1f);
               
            }
            for (int i = 0; i < 6; i++)
            {
                GridPosition neighborPos = new GridPosition();
                int x = (int) (position.x + neighborsDirections[i].x);
                int y = (int) (position.y + neighborsDirections[i].y);
                if (GetComponentInParent<Board>().getCellByCoords(x, y) != null)
                {
                    neighbors.Add(GetComponentInParent<Board>().getCellByCoords(x, y));
                }
                

            }
            return neighbors;
        }

    }
}