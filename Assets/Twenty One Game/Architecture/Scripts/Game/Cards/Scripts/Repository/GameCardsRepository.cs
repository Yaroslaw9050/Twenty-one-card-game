using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards.Game
{
    [RequireComponent(typeof(CardsGenerator))]
    public class GameCardsRepository : CardsRepository
    {
        public static GameCardsRepository Instance;
        
        private void Awake()
        {
            if(Instance != null) return;
            Instance = this;
        }
    }
}
