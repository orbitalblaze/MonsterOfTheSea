using UnityEngine;
using Grid;
using UnityEngine.UI;

public class CarteEnMain : MonoBehaviour
{

	public Card cardPrefab;
	public int handID;

	// Use this for initialization
	void Start () {
		Button btn = GetComponentInChildren<Button>();
		btn.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnClick()
	{
		Board board = Board.current;
		print(board);
		Instantiate(cardPrefab).move(Board.current.getCellByCoords(0, 0));
		GetComponentInParent<CardHand>().deleteCard(this);
	}
}
