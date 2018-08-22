using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HunterDrawing : TurnState {

    public override void Enter()
    {
        Debug.Log("Entering HunterTurn");
        base.Enter();
        changeOverlay();
        drawChoiceScreen.gameObject.SetActive(true);
    }

    private void changeOverlay()
    {
        GameObject avatar = GameObject.Find("Avatar");
        avatar.GetComponent<Image>().sprite = gameManager.currentPlayer.token.gameObject.GetComponent<SpriteRenderer>().sprite;

        GameObject main = GameObject.Find("Main");
        Debug.Log("current player is " + gameManager.currentPlayer.name);
        main.GetComponent<CarteEnMain>().LoadHandUI(gameManager.currentPlayer.cardHand);
    }

    /*protected override void OnDraw()
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
    } */
}
