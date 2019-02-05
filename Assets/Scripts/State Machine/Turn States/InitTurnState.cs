using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid;

public class InitTurnState : TurnState
{
    public override void Enter()
    {
        Debug.Log("Entering InitTurnState");
        base.Enter();
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        gameManager.InitGame();
        dealer.Deal();
        yield return null;
        owner.ChangeState<WhaleDrawingState>();
    }

}
