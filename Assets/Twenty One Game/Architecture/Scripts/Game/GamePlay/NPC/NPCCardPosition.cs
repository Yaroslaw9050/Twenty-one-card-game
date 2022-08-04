using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Cards.Game
{
    [RequireComponent(typeof(NPCCardsRepository))]
    public class NPCCardPosition : CardScriptAnimation
    {
        [Range(0.2f, 2f)]
        [SerializeField] private float cardMoveTime = 1f;
        [SerializeField] private Transform[] cardsPosition;
        private NPCCardsRepository npcCards;
        private void Awake()
        {
            npcCards = gameObject.GetComponent<NPCCardsRepository>();
            npcCards.UpdateNPCCardCount.AddListener(MoveCardTo);
        }
        public override void MoveCardTo()
        {
            int number = npcCards.CardsPull.Count-1;
            
            npcCards.CardsPull[number].transform.DOMove(cardsPosition[number].position, cardMoveTime);
        }
        public override void UpdateCardPosition()
        {
            
        }

    }
}
