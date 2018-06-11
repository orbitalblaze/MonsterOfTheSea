using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid;

public class WhaleDrawing : TurnState
{
    public override void Enter()
    {
        Debug.Log("Entering WhaleDrawing");
        base.Enter();
           drawChoiceScreen.gameObject.SetActive(true);
    }
    protected override void OnDraw()
    {
        Debug.Log("OnDraw");
        StartCoroutine(EndDraw());
    }

    IEnumerator EndDraw()
    {
        Debug.Log("EndDraw");
        drawChoiceScreen.gameObject.SetActive(false);
        yield return null;
        owner.ChangeState<WhaleTurn>();
    }
}
