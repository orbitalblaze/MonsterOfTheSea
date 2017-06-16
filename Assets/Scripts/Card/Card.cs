using Grid;
using UnityEngine;

public class Card : MonoBehaviour
{
	private bool inDragging = false;
	private void OnMouseDown()
	{
		if (!inDragging)
		{
			GetComponentInParent<Cell>().GetComponentInParent<Board>().setCurrentDraggingCard(this);
			inDragging = true;
		}
		else
		{
			GetComponentInParent<Cell>().GetComponentInParent<Board>().setCurrentDraggingCard(null);
			inDragging = false;
		}
		
	}
	
	public void move(Cell target)
	{
		transform.SetParent(target.transform);
		transform.localPosition = new Vector3(0f, 0f, 0f);
	}
}