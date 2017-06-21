using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dealer : MonoBehaviour
{
	public static Dealer current;
	public Deck[] decks;

	private void Awake()
	{
		current = this;
		for (int i = 0; i < decks.Length; i++)
		{
			decks[i] = Instantiate(decks[i]);
			decks[i].transform.SetParent(transform);
		}
	}

	public Card Draw(String tarDeck)
	{
		foreach (Deck deck in decks)
		{
			if (deck.name == tarDeck)
			{
				print(deck.name);
				int cardNumber = 0;
				
				foreach (var card in deck.GetDeck())
				{
					cardNumber += card.number;
				}
				
		
				int cardIndex = Random.Range(0, cardNumber - 1);
				
				foreach (var card in deck.GetDeck())
				{
					cardIndex -= card.number;
					if (cardIndex <= 0)
					{
						print("card has been returned");
						return card;
					} 
				}
				
			}
		}
		return null;
	}
}
