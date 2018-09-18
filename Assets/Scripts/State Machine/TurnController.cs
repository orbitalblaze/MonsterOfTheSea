using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid;

public class TurnController : StateMachine
{
    public Board board;
    public GameManager gameManager;
    public Canvas Overlay;
    public Canvas drawWhaleChoiceScreen;
    public Canvas drawHunterChoiceScreen;
    public Dealer dealer;

    void Start()
    {
        ChangeState<InitTurnState>();
    }
}