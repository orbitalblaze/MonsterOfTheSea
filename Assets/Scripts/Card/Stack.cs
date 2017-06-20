using System;
using UnityEngine;

//Classe d'une cellule du plateau
public class Stack : MonoBehaviour
{
    public Card[] stack;

    private void Awake()
    {
        stack = GetComponentsInChildren<Card>();
    }
    
    
}