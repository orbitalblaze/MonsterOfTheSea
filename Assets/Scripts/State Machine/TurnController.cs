using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid;

public class TurnController : StateMachine
{
    public Board board;
    public Token whaleToken;
    public Token hunterToken;
    public Canvas drawChoiceScreen;

    void Start()
    {
        ChangeState<InitTurnState>();
    }
}