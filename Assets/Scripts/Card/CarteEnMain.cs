using UnityEngine;
using Grid;
using UnityEngine.UI;

public class CarteEnMain : MonoBehaviour
{

	private Card card;

	// Use this for initialization
	void Start () {
		var btn = GetComponentInChildren<Button>();
		btn.onClick.AddListener(OnClick);
	}

	private void OnClick()
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
	}
}
