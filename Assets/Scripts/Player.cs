using UnityEngine;

[RequireComponent(typeof(CardHand))]
public class Player : MonoBehaviour
{
    public string name;
    public Role role;
    public Token token { get {return role.token; } }
    public CardHand cardHand;

    private void Awake()
    {
        if (this.GetComponent<CardHand>() == null)
            this.gameObject.AddComponent<CardHand>();

        cardHand = this.GetComponent<CardHand>();
    }
}
