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

    public void Deal(int nbsCard, String tarDeck, CardHand cardHand)
    {
        print("dealing...");
        foreach (var deck in decks)
        {
            if (deck.name == tarDeck + "(Clone)")
            {
                Card[] drawed = deck.Deal(nbsCard);
                cardHand.AddCardInHand(drawed);
                
            }
        }
    }
}