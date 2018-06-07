using System.Collections.Generic;
using Grid;
using UnityEngine;

public class MovingCardBehavior : CardBehaviour
{
    public int MoveNbs;
    public bool[] Directions;

    public void Effect()
    {
        Debug.Log("pute");

        /*Card parentCard = GetComponentInParent<Card>();
        Cell parentCell = parentCard.GetComponentInParent<Cell>();
        List<Cell> neighbors = parentCell.getNeighbors();
        
        neighbors[0].GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", Color.blue);*/        
        
    }
}

