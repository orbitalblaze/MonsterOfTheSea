using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class TurnState : State
    {

        protected TurnController owner;
        public Board board { get { return owner.board;  } }
        public Token whaleToken { get { return owner.whaleToken; } }
        public Token hunterToken { get { return owner.hunterToken; } }

        protected virtual void Awake()
        {
            owner = GetComponent<TurnController>();
        }

        protected override void AddListeners ()
        {
        }

        protected override void RemoveListeners()
        {
        }
    }
}