using Grid;
using UnityEngine;

public class Card : MonoBehaviour
{
    //Events of card
    public delegate void CardAction(Card sender, CardType cardType);
    public static event CardAction OnCardPlay;

    public enum CardType : int { APPEL_NATURE = 0, LIEN_BESTIAL = 1, DEPLACEMENT = 2, ARMEMENT = 3};


    public CardType cardType;
    private bool inDragging = false;
    //Supprimer cette variable quand Deck.cardList sera un HashTable
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

    public void PlayCard()
    {
        OnCardPlay(this, cardType);
    }
	
	public void move(Cell target)
	{
		transform.SetParent(target.transform);
		transform.localPosition = new Vector3(0f,0f,-1f);
	}
}