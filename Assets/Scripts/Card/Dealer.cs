using UnityEngine;

public class Dealer : MonoBehaviour {

	public Stack initialDeck;
	private Stack deck;
	private Stack discards;
	

	public Card draw()
	{
		int cardNumber = 0;
		for (int i = 0; i < initialDeck.GetStack().Length; i++)
		{
			cardNumber += initialDeck.GetStack()[i].number;
		}
		
		int cardId = Random.Range(0, cardNumber - 1);
		
		for (int i = 0; i < initialDeck.GetStack().Length; i++)
		{
			cardId -= initialDeck.GetStack()[i].number;
			if (cardId <= 0)
			{
				return initialDeck.GetStack()[i];
			} 
		}
		return null;
	}
	
}
