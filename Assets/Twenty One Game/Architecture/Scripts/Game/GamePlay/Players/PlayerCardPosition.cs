using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Cards.Game
{
    [RequireComponent(typeof(PlayerCardsRepository))]
    public class PlayerCardPosition : CardScriptAnimation
    {
        [Range(0.2f, 2f)]
        [SerializeField] private float cardMoveTime = 1f;
        [SerializeField] private Transform[] cardsPosition;
        private PlayerCardsRepository playerCards;
        
        private void Awake()
        {
            playerCards = gameObject.GetComponent<PlayerCardsRepository>();
            playerCards.UpdateCardCount.AddListener(MoveCardTo);
        }
        public override void MoveCardTo()
        {
            int number = playerCards.CardsPull.Count-1;
            
            playerCards.CardsPull[number].transform.DOMove(cardsPosition[number].position, cardMoveTime);
        }
        public override void UpdateCardPosition()
        {
            
        }
    }
}
