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
    public Canvas drawWhaleChoiceScreen { get { return owner.drawWhaleChoiceScreen; } }
    public Canvas drawHunterChoiceScreen { get { return owner.drawHunterChoiceScreen; } }

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
        //InputController.fireEvent += OnFire;

    }

    protected override void RemoveListeners()
    {
        Debug.Log("Removing Listeners");
        Dealer.OnDraw -= OnDraw;
        Card.OnCardPlay -= OnCardPlay;
        GameManager.OnEndTurn -= OnEndTurn;
        //InputController.fireEvent -= OnFire;
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

    /*protected virtual void OnFire(object sender, InfoEventArgs<int> e)
    {

    }
    protected virtual void SelectTile(Point p)
    {
        /*if (pos == p || !board.tiles.ContainsKey(p))
            return;
        pos = p;
        tileSelectionIndicator.localPosition = board.tiles[p].center;
    }*/
}