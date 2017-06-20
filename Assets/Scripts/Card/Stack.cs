using System;
using UnityEngine;

//Classe d'une cellule du plateau
public class Stack : MonoBehaviour
{
    private Card[] stack;
    public Dealer dealerPrefab;
    private Dealer dealer;
    
    
    void Awake()
    {
        dealer = Instantiate(dealerPrefab);
        dealer.initialDeck = this;
        stack = GetComponentsInChildren<Card>();
    }

    public Dealer GetDealer()
    {
        return dealer;
    }

    public Card[] GetStack()
    {
        return stack;
    }
    
    
}