using Grid;
using UnityEngine;

public class Card : MonoBehaviour
{
	private bool inDragging = false;
	public int number;
	public bool onBoard = true;


	public void DragOnBoard()
	{
		if (!inDragging)
		{
			Board.current.setCurrentDraggingCard(this);
			inDragging = true;
		}
	}

	public void StopDragOnBoard()
	{
		if (inDragging) {
			Board.current.setCurrentDraggingCard (null);
			inDragging = false;
			
		}
	}
	
	public void move(Cell target)
	{
		transform.SetParent(target.transform);
		transform.localPosition = new Vector3(0f,0f,-1f);
	}
}