using UnityEngine;
using Game;

namespace Cards.Game
{   
    [RequireComponent(typeof(PlayerCardsRepository))]
    [RequireComponent(typeof(UIPlayerScoreController))]
    public class PlayerCardPrice : CardPrice
    {
        private PlayerCardsRepository playerCards;
        private UIPlayerScoreController uIPlayerScore;
        public int PriceValue
        {
            get{return priceValue;}
        }

        private void Awake()
        {
            playerCards = gameObject.GetComponent<PlayerCardsRepository>();
            uIPlayerScore = gameObject.GetComponent<UIPlayerScoreController>();
            playerCards.UpdateCardCount.AddListener(TakePrice);
        }
        private void TakePrice()
        {
            int cardNumber = playerCards.CardsPull.Count-1;

            TakeCardPrice((int)playerCards.CardsPull[cardNumber].GetComponent<CardSetting>().CardInfo.Numerals);
            uIPlayerScore.UpdateScoreTextValue(priceValue);

            if(priceValue > 21) GameEventManager.Instance.OnNPCWin.Invoke();
        }
    }
}
