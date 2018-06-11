using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid;

public class TurnState : State
{
    protected TurnController owner;
    public Board board { get { return owner.board;  } }
    public GameManager gameManager { get { return owner.gameManager; } }
    public Dealer dealer { get { return owner.dealer; } }
    public Canvas drawChoiceScreen { get { return owner.drawChoiceScreen; } }

    protected virtual void Awake()
    {
        owner = GetComponent<TurnController>();
    }

    protected override void AddListeners ()
    {
        Debug.Log("Adding Listeners");
        Dealer.OnDraw += OnDraw;
        Card.OnCardPlay += OnCardPlay;

    }

    protected override void RemoveListeners()
    {
        Debug.Log("Removing Listeners");
        Dealer.OnDraw -= OnDraw;
        Card.OnCardPlay -= OnCardPlay;
    }

    protected virtual void OnDraw()
    {

    }

    protected virtual void OnCardPlay(object sender, Card.CardType cardType)
    {

    }
}