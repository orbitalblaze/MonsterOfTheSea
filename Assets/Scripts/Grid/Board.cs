using UnityEngine;
namespace Grid
{
    public class Board : MonoBehaviour
    {
        private Cell[,] cells;
        public int width = 19;
        public int height = 10;

        public Cell cellPrefab;

        void Awake()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x,y] = createCell(x, y);
                }
            }
        }
        
        void Start()
        {
            
        }

        private Cell createCell(int x, int y)
        {
            Cell createdCell = Instantiate<Cell>(cellPrefab);
            
            return createdCell;
        }

        public void onClick(int x, int y)
        {
            
        }
       
     }
}