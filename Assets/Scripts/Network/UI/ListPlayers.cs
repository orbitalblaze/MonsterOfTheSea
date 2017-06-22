using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ListPlayers : MonoBehaviour {
	
	public Text prefabRoomButton;
	public List<Text> listNamePlayer;
	
	void Awake () {
		listNamePlayer = new List<Text> ();
	}

	public void showPlayers (PhotonPlayer[] listPlayers)
	{
		foreach (Text namePlayer in listNamePlayer) {
			Destroy (namePlayer);
		}
		listNamePlayer.Clear ();

		print("Players available");
		print (listPlayers.Length);
		foreach (PhotonPlayer player in listPlayers) {
			print(player.ToString() + "name : "+ player.NickName);
			Text textPlayer = Instantiate<Text>(prefabRoomButton);
			textPlayer.transform.SetParent(this.transform);
			textPlayer.text = player.NickName;
			listNamePlayer.Add(textPlayer);
		}
	}
}
