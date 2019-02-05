using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid;

public class WhaleTurn : TurnState
{
    public override void Enter()
    {
        Debug.Log("Entering WhaleTurn");
        base.Enter();
    }

    protected override void OnCardPlay(object sender, Card.CardType cardType)
    {
        switch (cardType)
        {
            case Card.CardType.APPEL_NATURE:
                Debug.Log("Appel Nature");
                break;
            case Card.CardType.LIEN_BESTIAL:
                Debug.Log("Lien Bestial");
                break;
        }
    }



    protected override void OnEndTurn()
    {
        owner.ChangeState<WhaleEndTurnState>();
    }
}
