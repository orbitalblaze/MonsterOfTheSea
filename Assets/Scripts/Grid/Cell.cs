using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class Cell : MonoBehaviour
    {
        public GridPosition position;


        public bool isNeighbor(Cell clickedCell)
        {
            List<Cell> neighbors = this.getNeighbors();
            foreach (Cell cell in neighbors)
            {
                if (clickedCell.Equals(cell))
                {
                    return true;
                }
                
            }
            return false;
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
                int y = (int) ((position.y + neighborsDirections[i].y + GetComponentInParent<Board>().height) % GetComponentInParent<Board>().height);
                if (GetComponentInParent<Board>().getCellByCoords(x, y) != null)
                {
                    neighbors.Add(GetComponentInParent<Board>().getCellByCoords(x, y));
                }
            }
            return neighbors;
        }
    }
}