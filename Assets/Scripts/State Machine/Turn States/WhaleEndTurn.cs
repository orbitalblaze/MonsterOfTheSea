using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid;

public class WhaleEndTurn : TurnState
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
        if (gameManager.currentPlayer.role.roleType.Equals(Role.CHASSEUR))
        {
            owner.ChangeState<HunterDrawing>();
        }
        else
        {
            owner.ChangeState<WhaleDrawing>();
        }
    }
}
