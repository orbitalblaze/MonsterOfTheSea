using UnityEngine;
using System.Collections;
using System.Collections.Generic;

	public class ListRoom : MonoBehaviour {

		public Lobby lobby;
		public GameObject prefabRoomButton;
		public List<GameObject> listRoomButton;
	
		void Awake () {
			listRoomButton = new List<GameObject> ();
		}

		// Use this for initialization
		void Start () {
			getRooms ();	
		}
	
		// Update is called once per frame
		void Update () {
	
		}

		public void getRooms ()
		{
			RoomInfo[] rooms = lobby.GetRoomList();
			foreach (RoomInfo room in rooms) {
				GameObject newButton = Instantiate<GameObject>(prefabRoomButton);
				newButton.transform.parent = this.transform;
				RoomButton infoButton = newButton.GetComponent<RoomButton>();
				infoButton.text.text = room.Name + "(" + room.PlayerCount +"/" + room.MaxPlayers + ")";
				infoButton.roomName = room.Name;
				listRoomButton.Add(newButton);
			}
		}
	}
