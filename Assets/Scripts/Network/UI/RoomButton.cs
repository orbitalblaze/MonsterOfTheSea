using UnityEngine;
using System.Collections;
using UnityEngine.UI;

	public class RoomButton : MonoBehaviour {
		public string roomName;
		public Text text;
		public string name;

		void Awake ()
		{
			text = GetComponentInChildren<Text> ();
		}

	}
