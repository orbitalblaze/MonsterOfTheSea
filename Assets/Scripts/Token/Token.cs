using UnityEngine;
using Grid;
using System.Collections.Generic;

public class Token : MonoBehaviour {
    public int movementPerTurn = 0;
    public int movementLeft = 0;
    public Player owner;
    public Vector2Int startPosition;
    public Vector2Int orientation = Vector2Int.up;
    private Transform startParent;
    public bool movable = false;

    public void Update()
    {
        Quaternion tokenRotation;
       if(GetComponentInParent<Cell>().position.x % 2 != 0)
        {
            if (orientation == new Vector2Int(-1, 0))
            {
                tokenRotation = Quaternion.Euler(0, 0, 60);
            }
            else if (orientation == new Vector2Int(-1, -1))
            {
                tokenRotation = Quaternion.Euler(0, 0, 120);
            }
            else if (orientation == Vector2Int.down)
            {
                tokenRotation = Quaternion.Euler(0, 0, 180);
            }
            else if (orientation == new Vector2Int(1, -1))
            {
                tokenRotation = Quaternion.Euler(0, 0, -120);
            }
            else if (orientation == new Vector2Int(1, 0))
            {
                tokenRotation = Quaternion.Euler(0, 0, -60);
            }
            else
            {
                tokenRotation = Quaternion.Euler(0, 0, 0);
            }
        }
       else
        {
            if (orientation == new Vector2Int(-1, 1))
            {
                tokenRotation = Quaternion.Euler(0, 0, 60);
            }
            else if (orientation == new Vector2Int(-1, 0))
            {
                tokenRotation = Quaternion.Euler(0, 0, 120);
            }
            else if (orientation == Vector2Int.down)
            {
                tokenRotation = Quaternion.Euler(0, 0, 180);
            }
            else if (orientation == new Vector2Int(1, 0))
            {
                tokenRotation = Quaternion.Euler(0, 0, -120);
            }
            else if (orientation == new Vector2Int(1, 1))
            {
                tokenRotation = Quaternion.Euler(0, 0, -60);
            }
            else
            {
                tokenRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        transform.rotation = tokenRotation;
    }

    public void move(Cell target)
    {
        //Trouver le moyen de le transformer en vecteur "unitaire"
        //orientation = GetComponentInParent<Cell>().direction(target);
        transform.SetParent(target.transform);
        transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    private void OnMouseDown()
    {
        if(movable && movementLeft > 0)
        {
            getCellsToMoveTo();

        }
    }

    public List<Cell> getCellsToMoveTo()
    {
        Queue<Cell> cellsToCheckNow = new Queue<Cell>();
        Queue<Cell>  cellsToCheckNext = new Queue<Cell>();
        List<Cell> cellsToShow = new List<Cell>();

        Cell start = GetComponentInParent<Cell>();

        cellsToCheckNow.Enqueue(start);

        while(cellsToCheckNow.Count > 0)
        {
            Cell cell = cellsToCheckNow.Dequeue();
            print("Processing neightbor cells...");

            foreach (Cell neightborCell in cell.getNeighbors())
            {
                print("Considering cell at x:"+ neightborCell.position.x+ " y:" + neightborCell.position.y);
                print("Distance from center cell is " + neightborCell.distanceFrom(start));
                if(neightborCell.distanceFrom(start) <= movementLeft && 
                    neightborCell.distanceFrom(start) > cell.distanceFrom(start) && 
                    neightborCell.getToken() == null &&
                    cellsToCheckNext.Contains(neightborCell) == false)
                {
                    print("Cell pass test successfully. Enqueueing...");
                    cellsToCheckNext.Enqueue(neightborCell);
                }
            }
            cellsToShow.Add(cell);

            if(cellsToCheckNow.Count == 0)
            {
                Queue<Cell> temp = cellsToCheckNow;
                cellsToCheckNow = cellsToCheckNext;
                cellsToCheckNext = temp;
            }
        }

        foreach(Cell cell in cellsToShow)
        {
            print("Showing cell at x:"+ cell.position.x + " y:" + cell.position.y);
            cell.GetComponentInChildren<MeshRenderer>().material.SetColor("_Color", new Color(0f, 1f, 0f, 0.8f));
        }

        return cellsToShow;
    }
}
