using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class WhaleDrawing : TurnState
    {
        public override void Enter()
        {
            Debug.Log("Entering WhaleDrawing");
            DrawWhale();
        }

        void DrawWhale()
        {
            Debug.Log("pute1");
            drawChoiceScreen.gameObject.SetActive(true);
        }
        
    }
}
