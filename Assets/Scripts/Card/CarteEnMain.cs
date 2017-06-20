using UnityEngine;
using Grid;
using UnityEngine.UI;

public class CarteEnMain : MonoBehaviour
{

	public Card card;

	// Use this for initialization
	void Start () {
		Button btn = GetComponentInChildren<Button>();
		btn.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		Board board = Board.current;
		print(board);
		card.move(Board.current.getCellByCoords(0, 0));
		GetComponentInParent<CardHand>().deleteCard(this);
	}

	public void init(Card card)
	{
		this.card = card;
	}
}
