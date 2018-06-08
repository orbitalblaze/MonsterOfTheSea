using UnityEngine;
using Grid;
public class Token : MonoBehaviour {
    public int movementPerTurn = 0;
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
        orientation = GetComponentInParent<Cell>().direction(target);
        transform.SetParent(target.transform);
        transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    private void OnMouseDown()
    {
        if(movable)
        {

        }
    }
}
