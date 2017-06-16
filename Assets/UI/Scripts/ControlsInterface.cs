using UnityEngine;
using System.Collections;

public class ControlsInterface : MonoBehaviour {

	public GameObject Menu;

	void Update(){

		//Appuyer sur Echap : ouvrir Menu / fermer Menu
		if (Input.GetKeyDown ("escape")) {
			if (!Menu.activeSelf){
				Menu.SetActive(true);
			}else{
				Menu.SetActive(false);
			}
		}

		//Appuyer sur Espace : fin du tour
		if (Input.GetKeyDown ("space")) {
			//A COMPLETER
		}
	}

}
