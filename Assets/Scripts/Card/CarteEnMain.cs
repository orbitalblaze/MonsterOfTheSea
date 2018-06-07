using UnityEngine;
using Grid;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CarteEnMain : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{

	public Card card;
    public Player player;
	private Vector3 startingPosition;

	// Use this for initialization
	void Start () {
		var btn = GetComponentInChildren<Button>();
		//btn.onClick.AddListener(OnClick);
	}

	public void OnBeginDrag(PointerEventData data)
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
			GetComponentInParent<CardHand>().RemoveCard (card);
			card.StopDragOnBoard();
		}
		else if(!card.onBoard && Board.current.hovered)
        {
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
	}*/

	public void SetCard(Card initCard)
	{
		card = initCard;
		GetComponent<Image>().sprite = card.GetComponentInChildren<SpriteRenderer>().sprite;
	}
}
