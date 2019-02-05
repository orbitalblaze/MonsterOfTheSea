using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid;

public class WhaleEndTurnState : TurnState
{

    public override void Enter()
    {
        Debug.Log("Entering WhaleEndTurn");
        base.Enter();
        StartCoroutine(ChangeTurn());
    }

    IEnumerator ChangeTurn()
    {
        Debug.Log("Changing Turn");
        yield return null;
        if ((int) gameManager.currentPlayer.role.roleType == (int) Role.CHASSEUR)
        {
            owner.ChangeState<HunterDrawingState>();
        }
        else
        {
            owner.ChangeState<WhaleDrawingState>();
        }
    }
}
