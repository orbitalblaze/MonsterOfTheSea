using System.Collections.Generic;
using Grid;
using UnityEngine;

public interface MovingCardBehavior
{
    int MoveNbs { get; set; }
    bool[] Directions { get; set; }
    void Effect();
}

public class CardBehaviorScript : MonoBehaviour, MovingCardBehavior
{
    public int MoveNbs { get; set; }
    public bool[] Directions { get; set; }

    public void Effect()
    {
        Card parentCard = GetComponentInParent<Card>();
        Cell parentCell = parentCard.GetComponentInParent<Cell>();
        List<Cell> neighbors = parentCell.getNeighbors();
        
    }
}

