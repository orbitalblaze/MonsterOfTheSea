﻿using System.Collections.Generic;
using UnityEngine;

//Classe d'une cellule du plateau
public class Deck : MonoBehaviour
{
    public Card[] cardList;
    public List<Card> cardsInDeck;
    public List<Card> cardsInGame;
    public List<Card> discardPile;

    void Awake()
    {
       cardsInDeck = new List<Card>();
       cardsInGame = new List<Card>();
       discardPile = new List<Card>();

       Shuffle();
    }

   public void Shuffle()
   {
      foreach (var card in cardList)
      {
         for (int i = 0; i < card.number; i++)
         {
            cardsInDeck.Add(card);
         }
      }
   }

   public Card Draw()
   {
      int index = Random.Range(0, cardsInDeck.Count);
      Card drawed = cardsInDeck[index];
      cardsInDeck.RemoveAt(index);
      return drawed;
      

   }

   public Card[] Deal(int nbsCard)
   {
      Card[] toDeal = new Card[nbsCard];
      for (int i = 0; i < nbsCard; i++)
      {
         toDeal[i] = Instantiate(Draw());
         toDeal[i].transform.SetParent(CardInstanceBox.current.transform);
         toDeal[i].transform.localPosition = Vector3.zero;
         cardsInGame.Add(toDeal[i]);
         
      }
      return toDeal;
   }
   
}
