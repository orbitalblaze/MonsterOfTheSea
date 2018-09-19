﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid;

public class GameManager : MonoBehaviour
{
    public Board board;
    public Player PlayerPrefab;
    public List<Player> players;
    public List<Player> turnOrder;
    public List<Role> roles;
    public Player currentPlayer;
    public int roundNumber = 0 ;

    public delegate void TurnAction();
    public static event TurnAction OnEndTurn;

    private void Awake()
    {
        players = new List<Player>();
        turnOrder = new List<Player>();
    }

    public void InitGame()
    {
        //A remplacer par une fonction dynamique
        AddPlayers();
        DealRoles();
        SpawnTokenPlayer();
        NewRound();
        currentPlayer = players[0];
    }

    void AddPlayers()
    {
        Player player = Instantiate(PlayerPrefab);
        player.name = "Baleine";
        players.Add(player);

        player = Instantiate(PlayerPrefab);
        player.name = "Chasseur1";
        players.Add(player);

        player = Instantiate(PlayerPrefab);
        player.name = "Chasseur2";
        players.Add(player);

        player = Instantiate(PlayerPrefab);
        player.name = "Chasseur3";
        players.Add(player);
    }

    void DealRoles()
    {
        foreach(Player player in players)
        {
            player.role = roles[0];
            roles.RemoveAt(0);
        }
    }

    void SpawnTokenPlayer ()
    {
        foreach (Player player in players)
        {
            GameObject token = Instantiate(player.token.gameObject, 
                board.getCellByCoords(player.token.startPosition.x, player.token.startPosition.y).transform);
        }
    }

    public void EndTurn()
    {
        OnEndTurn();
        turnOrder.RemoveAt(0);
        if (turnOrder.Count == 0)
            NewRound();

        currentPlayer = turnOrder[0];
        OnEndTurn();
    }

    void NewRound()
    {
        Debug.Log("New Round");
        turnOrder = new List<Player>(players);

        roundNumber++;
    }
}
