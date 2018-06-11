using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dealer : MonoBehaviour
{
    //Events of deck
    public delegate void DeckAction();
    public static event DeckAction OnDraw;
    // ? Creer des constantes pour les noms des decks
    public static Dealer current;
    public Deck[] decks;
    //Temporaire : le temps d'avoir un système qui permet d'accèder à l'ensemble des joueurs
    public GameManager gameManager;

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
    public void Deal()
    {
        print("dealing...");
        foreach (Player player in gameManager.players)
        {
            if(player.role.roleType == Role.BALEINE)
            {
                Draw(3, "appelNature", player);
                Draw(3, "lienBestial", player);
            }
            else
            {
                //Draw(3, "armement", player);
                Draw(3, "deplacement", player);
            }
        }
    }


    //Faire une surcharge Draw(int nbsCard, String tarDeck) ou alors donner par défaut au joueur actif
    public void Draw(int nbsCard, String targetDeck, Player targetPlayer)
    {
        //On cherche aux travers de tout les gameobjects le deck demandé. IT'S A MATCH!
        foreach (var deck in decks)
        {            
            if (deck.name == targetDeck + "(Clone)")
            {
                //On répète l'opération le nombre de fois demandé
                for(int i = 0; i<nbsCard; i++)
                {
                    Card[] drawed = deck.Deal(nbsCard);
                    targetPlayer.cardHand.AddCardInHand(drawed);
                    OnDraw();
                }
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
                gameManager.currentPlayer.cardHand.AddCardInHand(drawed);
                OnDraw();
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