using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardHand : MonoBehaviour
{
	public List<CarteEnMain> hand;

	public CarteEnMain cartePrefab;
	// Use this for initialization
	void Awake () {
		
		hand.Add(Instantiate<CarteEnMain>(cartePrefab));
		hand.Add(Instantiate<CarteEnMain>(cartePrefab));
		hand.Add(Instantiate<CarteEnMain>(cartePrefab));
		hand.Add(Instantiate<CarteEnMain>(cartePrefab));
		hand.Add(Instantiate<CarteEnMain>(cartePrefab));
		hand.Add(Instantiate<CarteEnMain>(cartePrefab));
		hand.Add(Instantiate<CarteEnMain>(cartePrefab));
		hand.Add(Instantiate<CarteEnMain>(cartePrefab));
		hand.Add(Instantiate<CarteEnMain>(cartePrefab));

		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < hand.Count; i++)
		{
			hand[i].transform.SetParent(transform);
			hand[i].transform.localPosition = new Vector3(35 + ((478 / hand.Count) * i), 0, 0f);
			hand[i].transform.localScale = new Vector3(1f, 1f, 1f);
		}
	}

	public void addCard(Card card)
	{
		hand.Add(Instantiate<CarteEnMain>(cartePrefab));
	}
}
