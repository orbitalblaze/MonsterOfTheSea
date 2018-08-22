using System.Collections;
using System.Collections.Generic;
using Grid;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UICard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Card card;
    private Vector3 startingPosition;

    public void OnBeginDrag(PointerEventData data)
    {
        startingPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("At start" + this.transform.position);
        this.transform.position = eventData.position;
        if (card.onBoard)
        {
            if (Board.current.hovered)
            {
                this.GetComponent<Image>().enabled = false;
                card.DragOnBoard();
            }
            else
            {
                this.GetComponent<Image>().enabled = true;
                card.StopDragOnBoard();
                card.transform.SetParent(CardInstanceBox.current.transform);
                card.transform.localPosition = Vector3.zero;
                Debug.Log("At end" + this.transform.position);
            }
        }       
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (card.onBoard && Board.current.hovered)
        {
            card.PlayCard();
            GetComponentInParent<CarteEnMain>().displayedHand.RemoveCard(card);
            card.StopDragOnBoard();
        }
        else if (!card.onBoard && Board.current.hovered)
        {
            card.PlayCard();
            GetComponentInParent<CarteEnMain>().displayedHand.RemoveCard(card);
            card.GetComponent<MovingCardBehavior>().Effect();
        }
        else
        {
            transform.position = startingPosition;
        }
    }
}
