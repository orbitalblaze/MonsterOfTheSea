using System.Collections.Generic;
using UnityEngine;

//Classe d'une cellule du plateau
public class Deck : MonoBehaviour
{
    private Card[] cards;

    public List<Card> deck;

    public List<Card> discardPile;
    
    void Awake()
    {
        cards = GetComponentsInChildren<Card>();
        print(cards.Length);
        foreach (Card card in cards)
        {
            deck.Add(card);
        }
    }

    public List<Card> GetDeck()
    {
        return deck;
    }
    
}