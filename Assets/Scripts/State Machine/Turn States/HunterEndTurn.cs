using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterEndTurn : TurnState {

    public override void Enter()
    {
        Debug.Log("Entering HunterEndTurn");
        base.Enter();
        StartCoroutine(ChangeTurn());
    }

    IEnumerator ChangeTurn()
    {
        Debug.Log("Changing Turn");
        yield return null;
        if ((int)gameManager.currentPlayer.role.roleType == (int)Role.CHASSEUR)
        {
            owner.ChangeState<HunterDrawing>();
        }
        else
        {
            owner.ChangeState<WhaleDrawing>();
        }
    }
}
