using UnityEngine;
using Grid;
public class Token : MonoBehaviour {
    public int movementPerTurn = 0;
    public Player owner;
    private Vector3 startPosition;
    private Transform startParent;

    public void move(Cell target)
    {
        transform.SetParent(target.transform);
        transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    
}
