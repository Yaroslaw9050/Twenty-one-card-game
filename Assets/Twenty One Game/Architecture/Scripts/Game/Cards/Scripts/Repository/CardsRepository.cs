using System.Collections.Generic;
using UnityEngine;

namespace Cards.Game
{
    public class CardsRepository : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> cardsPull;
        private void Awake()
        {
            cardsPull = new List<GameObject>();
        }
        public virtual void AddCardToPull(GameObject cardObject)
        {
            if(!cardObject.GetComponent<CardSetting>()) return;

            cardsPull.Add(cardObject);
        }
        public virtual GameObject GetRandomCard()
        {
            int randomValue = Random.Range(0, cardsPull.Count);
            GameObject card = cardsPull[randomValue];
            cardsPull.RemoveAt(randomValue);
            return card;
        }
    }
}
