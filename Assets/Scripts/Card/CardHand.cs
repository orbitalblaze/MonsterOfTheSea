using UnityEngine;
using System.Collections.Generic;

public class CardHand : MonoBehaviour
{
	public List<Card> hand;

	public CarteEnMain cartePrefab;

	private int lastNumberOfCardInHand;
	// Use this for initialization
	void Start ()
	{
		Dealer.current.Deal(3, "lienBestial", this);
		Dealer.current.Deal(3, "deplacement", this);
	}
	
	// Update is called once per frame
	void Update () {
		if (lastNumberOfCardInHand != hand.Count)
		{	
			lastNumberOfCardInHand = hand.Count;
			
			foreach (var child in GetComponentsInChildren<CarteEnMain>())
			{
				Destroy(child.gameObject);
			}
			
			for (int i = 0; i < hand.Count; i++)
			{
				CarteEnMain uiCard = Instantiate(cartePrefab);
				uiCard.SetCard(hand[i]);
				uiCard.transform.SetParent(transform);
				uiCard.transform.localPosition = new Vector3(35 + 478 / hand.Count * i, 0f, 0f);
				uiCard.transform.localScale = new Vector3(1f, 1f, 1f);
			}
		}
	}


	public void RemoveCard(Card card)
	{
		hand.Remove(card);
	}

	public void AddCardInHand(Card[] drawed)
	{
		foreach (var card in drawed)
		{
			hand.Add(card);
		}
	}
}
