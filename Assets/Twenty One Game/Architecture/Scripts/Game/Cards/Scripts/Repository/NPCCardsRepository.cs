using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cards.Game
{
    public class NPCCardsRepository : CardsRepository
    {
        [HideInInspector] public UnityEvent UpdateNPCCardCount;
        public List<GameObject> CardsPull
        {
            get{return cardsPull;}
        }
        public override void AddCardToPull(GameObject cardObject)
        {
            base.AddCardToPull(cardObject);
            //cardObject.GetComponent<CardSetting>().TurnCard();
            UpdateNPCCardCount.Invoke();
        }
    }
}
