using UnityEngine;

public class Dealer : MonoBehaviour {

	public Stack initialDeck;
	private Stack deck;
	private Stack discards;
	

	public Card draw()
	{
		int cardNumber = 0;
		for (int i = 0; i < initialDeck.stack.Length; i++)
		{
			cardNumber += initialDeck.stack[i].number;
		}
		
		int cardId = Random.Range(0, cardNumber - 1);
		
		for (int i = 0; i < initialDeck.stack.Length; i++)
		{
			cardId -= initialDeck.stack[i].number;
			if (cardId <= 0)
			{
				return initialDeck.stack[i];
			} 
		}
		return null;
	}
	
}
