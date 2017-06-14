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
        
        

        void Awake()
        {
            cells = new Cell[width,height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x,y] = createCell(x, y);
                }
            }
        }
        
        void Update()
        {
            
            print(clickedCells.Count);
            if ((clickedCells.Count) == 2)
            {
                List<Cell> neighbors = clickedCells[0].getNeighbors();
                foreach(Cell cell in neighbors)
                {
                    cell.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", Color.white);
                }
                
                
                if (clickedCells[0].isNeighbor(clickedCells[1].position))
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
            if (!((x < 0 || x > width) || (y < 0 || y > height)))
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
    }
}