using System;
using UnityEngine;
using System.Collections.Generic;
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
    public List<Card> revealedCards;

    private void Awake()
    {
        revealedCards = new List<Card>();
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
                Draw(3, "armement", player);
                Draw(2, "deplacement", player);
            }
        }
    }

    public void Draw(int nbsCard, String targetDeck, Player targetPlayer)
    {
        //On cherche aux travers de tout les gameobjects le deck demandé. IT'S A MATCH!
        foreach (var deck in decks)
        {            
            if (deck.name == targetDeck + "(Clone)")
            {
                Card[] drawed = deck.Draw(nbsCard);
                targetPlayer.cardHand.AddCardInHand(drawed);
                OnDraw();
            }
        }
    }

    public void Draw(int nbsCard, String targetDeck)
    {
        foreach (var deck in decks)
        {
            if (deck.name == targetDeck + "(Clone)")
            {
                Card[] drawed = deck.Draw(nbsCard);
                gameManager.currentPlayer.cardHand.AddCardInHand(drawed);
                OnDraw();
            }
        }
    }

    public void Discard(Card card)
    {
        decks[(int) card.cardType].Discard(card);
    }

    public void Reveal(int nbsCard, String targetDeck)
    {
        foreach (var deck in decks)
        {
            if (deck.name == targetDeck + "(Clone)")
            {
                Card[] drawed = deck.Draw(nbsCard);
                foreach (var card in drawed)
                {
                    revealedCards.Add(card);
                }
            }
        }
    }

    public void Pick (int indexCard)
    {
        gameManager.currentPlayer.cardHand.AddCardInHand(revealedCards[indexCard]);
        foreach (var revealedCard in revealedCards)
        {
            Discard(revealedCard);
        }
        revealedCards.Clear();
        OnDraw();
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