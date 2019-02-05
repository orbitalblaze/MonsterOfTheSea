using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HunterDrawingState : TurnState {

    public override void Enter()
    {
        Debug.Log("Entering HunterDrawing");
        base.Enter();
        changeOverlay();
        
        //Prepare choice screen for movement cards
        Button[] choices = drawHunterChoiceScreen.GetComponentsInChildren<Button>();
        dealer.Reveal(2, "deplacement");
        for(int i = 0; i < dealer.revealedCards.Count; i++)
        {
            Debug.LogWarning("This card is "+dealer.revealedCards[i].name);
            setCardChoiceButton(choices[i], i);
        }
        drawHunterChoiceScreen.gameObject.SetActive(true);
    }

    private void setCardChoiceButton(Button button, int indexCard)
    {
        button.GetComponent<Image>().sprite = dealer.revealedCards[indexCard].GetComponentInChildren<SpriteRenderer>().sprite;
        button.onClick.AddListener(() => dealer.Pick(indexCard));
    }

    private void changeOverlay()
    {
        GameObject avatar = GameObject.Find("Avatar");
        avatar.GetComponent<Image>().sprite = gameManager.currentPlayer.token.gameObject.GetComponent<SpriteRenderer>().sprite;

        GameObject lifeCounter = GameObject.Find("TextPdv");
        lifeCounter.GetComponent<Text>().text = gameManager.huntersLifePoint.ToString();

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
        drawHunterChoiceScreen.gameObject.SetActive(false);
        yield return null;
        owner.ChangeState<HunterTurnState>();
    } 
}
