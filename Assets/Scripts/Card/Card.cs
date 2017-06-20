using Grid;
using UnityEngine;

public class Card : MonoBehaviour
{
	private bool inDragging = true;
	public int number;

	private void Awake()
	{
		Board.current.setCurrentDraggingCard(this);
		
	}

	private void OnMouseDown()
	{
		if (!inDragging)
		{
			Board.current.setCurrentDraggingCard(this);
			inDragging = true;
		}
		else
		{
			Board.current.setCurrentDraggingCard(null);
			inDragging = false;
		}
		
	}
	
	public void move(Cell target)
	{
		transform.SetParent(target.transform);
		transform.localPosition = new Vector3(0f, 0f, 0f);
	}
}