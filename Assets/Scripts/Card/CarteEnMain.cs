using UnityEngine;
using System.Collections.Generic;
using Grid;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CarteEnMain : MonoBehaviour//, IBeginDragHandler, IDragHandler, IEndDragHandler 
{

    public Player player;
	private Vector3 startingPosition;
    public UICard prefabUICard;
    public CardHand displayedHand;
    public List<UICard> displayedCards;

	// Use this for initialization
	void Start () {
		var btn = GetComponentInChildren<Button>();
        displayedCards = new List<UICard>();
        //btn.onClick.AddListener(OnClick);
        Dealer.OnDraw += OnDraw;
        Card.OnCardPlay += OnCardPlay;
    }

    public void LoadHandUI(CardHand handToDisplay)
    {
        Debug.Log("Loading UI Cards...");
        displayedHand = handToDisplay;

        foreach (var child in GetComponentsInChildren<UICard>())
        {
            Debug.Log("Destroying old UI Card...");
            Destroy(child.gameObject);
        }
        displayedCards.Clear();

        foreach (Card card in handToDisplay.hand)
        {
            Debug.Log("Instantiating " + card.name + "...");
            AddUICard(card);
        }
    }

	/*public void OnBeginDrag(PointerEventData data)
	{
		startingPosition = transform.position;
	}

	public void OnDrag(PointerEventData data)
	{
		transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        if (card.onBoard)
        {
            if (Board.current.hovered)
            {
                this.GetComponent<Image>().enabled = false;
                card.DragOnBoard();
            }
            else if (!Board.current.hovered)
            {
                this.GetComponent<Image>().enabled = true;
                card.StopDragOnBoard();
                card.transform.SetParent(CardInstanceBox.current.transform);
                card.transform.localPosition = Vector3.zero;
            }
        }

	}

	public void OnEndDrag(PointerEventData data)
	{
		if (card.onBoard && Board.current.hovered) {
            card.PlayCard();
            GetComponentInParent<CardHand>().RemoveCard (card);
			card.StopDragOnBoard();
		}
		else if(!card.onBoard && Board.current.hovered)
        {
            card.PlayCard();
            GetComponentInParent<CardHand>().RemoveCard(card);
            card.GetComponent<MovingCardBehavior>().Effect();
        }
		else {
			transform.position = startingPosition;
		}
	}

	/*private void OnClick()
	{
		Board board = Board.current;
		GetComponentInParent<CardHand>().RemoveCard(card);
		card = Instantiate(card);
		card.move(board.getCellByCoords(0, 0));
	}

	public void SetCard(Card initCard)
	{
		card = initCard;
		GetComponent<Image>().sprite = card.GetComponentInChildren<SpriteRenderer>().sprite;
	}*/

    public void AddUICard (Card initCard)
    {
        UICard uiCard = Instantiate(prefabUICard, this.transform);
        displayedCards.Add(uiCard);
        uiCard.card = initCard;
        uiCard.GetComponent<Image>().sprite = initCard.gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
    }

    private void OnDraw()
    {
        if(displayedHand != null)
        {
            LoadHandUI(displayedHand);
        }
    }

    private void OnCardPlay(Card sender, Card.CardType cardType)
    {
        displayedHand.RemoveCard(sender);
        if (displayedHand != null)
        {
            LoadHandUI(displayedHand);
        }
    }


    private void OnDestroy()
    {
        Dealer.OnDraw -= OnDraw;        
    }
}
