using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid;

public class InitTurnState : TurnState
{
    public override void Enter()
    {
        Debug.Log("Entering InitTurnState");
        base.Enter();
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        SpawnTokenPlayer();
        DealCards();
        yield return null;
        owner.ChangeState<WhaleDrawing>();
    }

    void SpawnTokenPlayer()
    {
        Instantiate(whaleToken.gameObject,
            board.getCellByCoords(whaleToken.startPosition.x, whaleToken.startPosition.y).transform);
        Instantiate(hunterToken.gameObject,
            board.getCellByCoords(hunterToken.startPosition.x, hunterToken.startPosition.y).transform);
        /*foreach (Player player in players)
         * {
         * GameObject token = Instantiate(player.token.gameObject,
         * board.getCellByCoords(player.token.startPosition.x, player.token.startPosition.y).transform);
         * }*/
    }

    void DealCards ()
    {

    }
}
