using UnityEngine;
using System.Collections.Generic;

public class CardHand : MonoBehaviour
{
	public List<CarteEnMain> hand;

	public CarteEnMain cartePrefab;

	private int lastNumberOfCardInHand;
	// Use this for initialization
	void Awake ()
	{
		for (int i = 0; i < 3; i++)
		{
			addCard(Dealer.current.Draw("appelNature"));
		}
		for (int i = 0; i < 3; i++)
		{
			addCard(Dealer.current.Draw("lienBestial"));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (lastNumberOfCardInHand != hand.Count)
		{
			foreach (CarteEnMain child in GetComponentsInChildren<CarteEnMain>())
			{
				child.transform.SetParent(null);
			}
			for (int i = 0; i < hand.Count; i++)
			{
				lastNumberOfCardInHand = hand.Count;
				hand[i].transform.SetParent(transform);
				hand[i].transform.localPosition = new Vector3(35 + ((478 / hand.Count) * i), 0f, 0f);
				hand[i].transform.localScale = new Vector3(1f, 1f, 1f);
			}
		}
	}

	public void addCard(Card card)
	{
		
		CarteEnMain carte = Instantiate(cartePrefab);
		carte.SetCard(card);
		hand.Add(carte);
		//carte.handID = hand.Count - 1;
	}

	public void deleteCard(CarteEnMain card)
	{
		hand.Remove(card);
	}
}
