using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dealer : MonoBehaviour
{
	public static Dealer current;
    public Deck[] decks;
    //Temporaire : le temps d'avoir un système qui permet d'accèder à l'ensemble des joueurs
    public Player player;

    private void Awake()
    {
        current = this;
        for (int i = 0; i < decks.Length; i++)
        {
            decks[i] = Instantiate(decks[i]);
            decks[i].transform.SetParent(transform);
        }
    }

    //Changer en une fonction qui distribue les cartes!
    //Changer l'obtention de la main par un objet joueur plutôt que sa main
    public void Deal(int nbsCard, String tarDeck, CardHand cardHand)
    {
        print("dealing...");
        foreach (var deck in decks)
        {
            if (deck.name == tarDeck + "(Clone)")
            {
                Card[] drawed = deck.Deal(nbsCard);
                cardHand.AddCardInHand(drawed);
                
            }
        }
    }


    //Faire une surcharge Draw(int nbsCard, String tarDeck) ou alors donner par défaut au joueur actif
    public void Draw(int nbsCard, String targetDeck, Player targetPlayer)
    {
        foreach (var deck in decks)
        {
            if (deck.name == targetDeck + "(Clone)")
            {
                Card[] drawed = deck.Deal(nbsCard);
                targetPlayer.cardHand.AddCardInHand(drawed);

            }
        }
    }

    public void Draw(int nbsCard, String targetDeck)
    {
        foreach (var deck in decks)
        {
            if (deck.name == targetDeck + "(Clone)")
            {
                Card[] drawed = deck.Deal(nbsCard);
                player.cardHand.AddCardInHand(drawed);

            }
        }
    }

    public void DrawAppelNature ()
    {
        Draw(1, "appelNature");
    }

    public void DrawLienBestial()
    {
        Draw(1, "lienBestial");
    }

    public void DrawDeplacement()
    {
        Draw(1, "deplacement");
    }

    public void DrawArmement()
    {
        Draw(1, "armement");
    }
}