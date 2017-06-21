using UnityEngine;
using System.Collections;

public class CardInstanceBox : MonoBehaviour
{

	public static CardInstanceBox current;
	// Use this for initialization`
	private void Awake()
	{
		current = this;
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
