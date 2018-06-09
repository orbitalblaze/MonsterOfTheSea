using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class TurnController : StateMachine
    {

        public Board board;
        public Token whaleToken;
        public Token hunterToken;
        public Canvas drawChoiceScreen;
        public Dealer dealer;

        void Start()
        {
            ChangeState<InitTurnState>();
        }
    }
}