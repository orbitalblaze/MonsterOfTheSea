using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid;
using System;
using UnityEngine.UI;

public class WhaleDrawing : TurnState
{
    public override void Enter()
    {
        Debug.Log("Entering WhaleDrawing");
        base.Enter();
        changeOverlay();
        drawWhaleChoiceScreen.gameObject.SetActive(true);
    }

    private void changeOverlay()
    {
        GameObject avatar = GameObject.Find("Avatar");
        avatar.GetComponent<Image>().sprite = gameManager.currentPlayer.token.gameObject.GetComponent<SpriteRenderer>().sprite;

        GameObject main = GameObject.Find("Main");
        Debug.Log("current player is " + gameManager.currentPlayer.name);
        main.GetComponent<CarteEnMain>().LoadHandUI(gameManager.currentPlayer.cardHand);
    }

    protected override void OnDraw()
    {
        Debug.Log("OnDraw");
        StartCoroutine(EndDraw());
    }

    IEnumerator EndDraw()
    {
        Debug.Log("EndDraw");
        drawWhaleChoiceScreen.gameObject.SetActive(false);
        yield return null;
        owner.ChangeState<WhaleTurn>();
    }
}
