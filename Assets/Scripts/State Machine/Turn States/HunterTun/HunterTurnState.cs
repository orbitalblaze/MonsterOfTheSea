using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterTurnState : TurnState {

    public override void Enter()
    {
        Debug.Log("Entering HunterTurn");
        base.Enter();
    }

    protected override void OnCardPlay(object sender, Card.CardType cardType)
    {
        switch (cardType)
        {
            case Card.CardType.DEPLACEMENT:
                Debug.Log("Deplacement");
                break;
            case Card.CardType.ARMEMENT:
                Debug.Log("Armement");
                break;
        }
    }

    protected override void OnEndTurn()
    {
        owner.ChangeState<HunterEndTurnState>();
    }
}
