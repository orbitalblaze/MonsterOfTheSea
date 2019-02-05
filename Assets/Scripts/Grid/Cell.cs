using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Grid
{
    public class Cell : MonoBehaviour, IDropHandler
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
            /*GetComponentInParent<Board>().newSelectedCell(this);*/

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
                if ((GetComponentInParent<Board>().getCellByCoords(x, y) != null) && (GetComponentInParent<Board>().getCellByCoords(x, y).GetComponentInChildren<Card>() == null) && (GetComponentInParent<Board>().getCellByCoords(x, y).GetComponentInChildren<Token>() == null) && (GetComponentInParent<Board>().getCellByCoords(x, y).GetComponentInChildren<Obstacle>() == null))
                {
                    neighbors.Add(GetComponentInParent<Board>().getCellByCoords(x, y));
                }
            }
            return neighbors;
        }

        public void OnDrop(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void mouseOver()
        {
            if ((GetComponentInChildren<Card>() == null) && (GetComponentInChildren<Token>() == null) && (GetComponentInChildren<Obstacle>() == null))
            {
				print("move over me");
                GetComponentInParent<Board>().mouseOverCell(this);
            }
        }

        public float distanceFrom (Cell target)
        {
            return offsetDistance(this, target);
        }

        public float offsetDistance(Cell cellA, Cell cellB)
        {
            var aCube = offsetOddQToCubeCoord(cellA);
            var bCube = offsetOddQToCubeCoord(cellB);
            return cubeDistance(aCube, bCube);
        }

        public Vector3 offsetOddQToCubeCoord(Cell cell)
        {
            var x = cell.position.x;
            var z = cell.position.y - ( cell.position.x - (cell.position.x%2)) / 2;
            var y = -x - z;
            return new Vector3(x, y, z);
        }

        public float cubeDistance (Vector3 a,Vector3 b)
        {
            return (Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z)) / 2;
        }

        public /*Vector2Int*/ void direction(Cell target)
        {
            //float distance = this.distance(target);
            //return new Vector2Int(Math.Sign(distance.x), Math.Sign(distance.y));
        }
    }
}