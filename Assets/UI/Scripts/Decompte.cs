using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Decompte : MonoBehaviour
{
    float timeLeft = 30.0f;

    public Text text;
    
    void Update()
    {
        timeLeft -= Time.deltaTime;
        text.text = "Temps restant : " + Mathf.Round(timeLeft) + "sec";
        if (timeLeft < 0)
        {
            //Application.LoadLevel("gameOver");
            text.text = "Fin du tour";
        }
    }
}