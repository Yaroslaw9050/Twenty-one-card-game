using UnityEngine;
using Game;

namespace Cards.Game
{   
    public class NPCCardPrice : CardPrice
    {
        public int PriceValue
        {
            get{return priceValue;}
        }
        private NPCCardsRepository npcCardsRepository;
        

        private void Awake()
        {
            npcCardsRepository = gameObject.GetComponent<NPCCardsRepository>();

            npcCardsRepository.UpdateNPCCardCount.AddListener(TakePrice);
            
        }
        private void TakePrice()
        {
            int cardNumber = npcCardsRepository.CardsPull.Count-1;

            TakeCardPrice((int)npcCardsRepository.CardsPull[cardNumber].GetComponent<CardSetting>().CardInfo.Numerals);

        }
    }
}