using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WhaleMovementState : TurnState
{
    public override void Enter()
    {
        Debug.Log("Entering WhaleMovement");
        base.Enter();
    }

    /*protected override void OnFire(object sender, InfoEventArgs<int> e)
    {
        if (tiles.Contains(owner.currentTile))
            owner.ChangeState<WhaleTurn>();
    }*/

    protected override void OnEndTurn()
    {
        owner.ChangeState<WhaleTurn>();
    }
}
