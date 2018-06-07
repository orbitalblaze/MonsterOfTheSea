using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class GameManager : MonoBehaviour
    {
        public Board board;
        public List<Player> players;
        // Use this for initialization
        void Start()
        {
            SpawnTokenPlayer();
        }

        void SpawnTokenPlayer ()
        {
            foreach (Player player in players)
            {
                GameObject token = Instantiate(player.token.gameObject, 
                    board.getCellByCoords(player.token.startPosition.x, player.token.startPosition.y).transform);
            }
        }
    }
}