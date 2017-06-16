using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Grid
{
    public class Board : MonoBehaviour
    {
        private Cell[,] cells;
        public int width = 19;
        public int height = 10;

        public Cell cellPrefab;
        
        private List<Cell> clickedCells = new List<Cell>();
        private Card currentDraggingCard;

        public Obstacle icebergPrefab;


        void Awake()
        {
            GridPosition[] icebergs = new GridPosition[30];
            icebergs[0] = new GridPosition(1, 1);
            icebergs[1] = new GridPosition(1, 9);
            icebergs[2] = new GridPosition(2, 4);
            icebergs[3] = new GridPosition(2, 5);
            icebergs[4] = new GridPosition(2, 9);
            icebergs[5] = new GridPosition(3, 0);
            icebergs[6] = new GridPosition(3, 3);
            icebergs[7] = new GridPosition(3, 9);
            icebergs[8] = new GridPosition(4, 0);
            icebergs[9] = new GridPosition(4, 7);
            icebergs[10] = new GridPosition(5, 2);
            icebergs[11] = new GridPosition(5, 7);
            icebergs[12] = new GridPosition(6, 2);
            icebergs[13] = new GridPosition(6, 3);
            icebergs[14] = new GridPosition(6, 5);
            icebergs[15] = new GridPosition(11, 2);
            icebergs[16] = new GridPosition(11, 3);
            icebergs[17] = new GridPosition(11, 6);
            icebergs[18] = new GridPosition(12, 2);
            icebergs[19] = new GridPosition(12, 9);
            icebergs[20] = new GridPosition(13, 1);
            icebergs[21] = new GridPosition(14, 5);
            icebergs[22] = new GridPosition(15, 0);
            icebergs[23] = new GridPosition(15, 7);
            icebergs[24] = new GridPosition(15, 8);
            icebergs[25] = new GridPosition(16, 0);
            icebergs[26] = new GridPosition(16, 1);
            icebergs[27] = new GridPosition(16, 3);
            icebergs[28] = new GridPosition(16, 4);
            icebergs[29] = new GridPosition(16, 5);
            
            
            cells = new Cell[width,height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x,y] = createCell(x, y);
                }
            }
            foreach (GridPosition obstPos in icebergs)
            {
                Obstacle iceberg = Instantiate<Obstacle>(icebergPrefab);
                iceberg.SetParentCell(getCellByCoords(obstPos.x, obstPos.y));
            }
        }
        
        void Update()
        {
            if ((clickedCells.Count) == 2)
            {
                List<Cell> neighbors = clickedCells[0].getNeighbors();
                foreach(Cell cell in neighbors)
                {
                    cell.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", Color.white);
                }
                
                
                if (clickedCells[0].isNeighbor(clickedCells[1]))
                {
                    clickedCells[0].getToken().move(clickedCells[1]);
                }
                clickedCells = new List<Cell>();
               
            }
            if ((clickedCells.Count) == 1)
            {
                List<Cell> neighbors = clickedCells[0].getNeighbors();
                foreach(Cell cell in neighbors)
                {
                    cell.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", Color.red);
                }
            }
        }

        private Cell createCell(int x, int y)
        {
            Cell createdCell = Instantiate<Cell>(cellPrefab);
            
            Vector3 cellPos = new Vector3();
            cellPos.x = x * (1.5f * HexMetrics.outerRadius);
            cellPos.y =  ((y % 10) * (2 * HexMetrics.innerRadius)) + (x % 2) * HexMetrics.innerRadius;
            cellPos.z = 0f;
            createdCell.transform.SetParent(transform, false);
            createdCell.transform.localPosition = cellPos;
            
            createdCell.position.x = x;
            createdCell.position.y = y;
            return createdCell;
        }

        public Cell getCellByCoords(int x, int y)
        {
            if (((x >= 0) && (x < width)) && ((y >= 0) && (y < height)))
            {
                return cells[x, y];
            }
            else
            {
                return null;
            }
        }
        
        public void newSelectedCell(Cell clickedCell)
        {
            if (clickedCells.Count == 0)
            {
                if (clickedCell.hasToken())
                {
                    clickedCells.Add(clickedCell);
                }
            } 
            else if (clickedCells.Count == 1)
            {
                clickedCells.Add(clickedCell);
            }
        }

        public void setCurrentDraggingCard(Card card)
        {
            this.currentDraggingCard = card;
        }

        public void mouseOverCell(Cell cell)
        {
            if (currentDraggingCard != null)
            {
                currentDraggingCard.move(cell);
            }
        }
    }
}