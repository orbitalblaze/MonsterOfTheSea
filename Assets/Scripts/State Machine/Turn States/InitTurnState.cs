using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class InitTurnState : TurnState
    {
        public override void Enter()
        {
            base.Enter();
            Init();
        }

        void Init()
        {
            SpawnTokenPlayer();
            owner.ChangeState<WhaleDrawing>();
        }

        void SpawnTokenPlayer()
        {
            Instantiate(whaleToken.gameObject,
                    board.getCellByCoords(whaleToken.startPosition.x, whaleToken.startPosition.y).transform);
            Instantiate(hunterToken.gameObject,
                    board.getCellByCoords(hunterToken.startPosition.x, hunterToken.startPosition.y).transform);
            /*foreach (Player player in players)
            {
                GameObject token = Instantiate(player.token.gameObject,
                    board.getCellByCoords(player.token.startPosition.x, player.token.startPosition.y).transform);
            }*/
        }
    }
}
