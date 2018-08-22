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
    public Canvas Overlay { get { return owner.Overlay; } }
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
        GameManager.OnEndTurn += OnEndTurn;

    }

    protected override void RemoveListeners()
    {
        Debug.Log("Removing Listeners");
        Dealer.OnDraw -= OnDraw;
        Card.OnCardPlay -= OnCardPlay;
        GameManager.OnEndTurn -= OnEndTurn;
    }

    protected virtual void OnDraw()
    {

    }

    protected virtual void OnCardPlay(object sender, Card.CardType cardType)
    {

    }

    protected virtual void OnEndTurn()
    {

    }
}