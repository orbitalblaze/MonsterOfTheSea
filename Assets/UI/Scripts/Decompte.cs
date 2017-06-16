using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Decompte : MonoBehaviour
{
	//temps d'un tour de jeu
    float timeLeft = 30.0f;

    public Text text;
    
    void Update()
    {
        timeLeft -= Time.deltaTime; //decompte, temps qui descend sec par sec
        text.text = Mathf.Round(timeLeft) + "";
        if (timeLeft < 0)
        {
            text.text = "0";
        }
    }
}