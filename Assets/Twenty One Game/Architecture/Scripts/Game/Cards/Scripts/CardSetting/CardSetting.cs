using UnityEngine;
using CustomSO;

namespace Cards.Game
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CardSetting : MonoBehaviour
    {
        public CardsSettingSO CardInfo
        {
            get{return cardInfo;}
        }
        [SerializeField] private CardsSettingSO cardInfo;
        private SpriteRenderer sprite;
        private void Awake()
        {
            sprite = gameObject.GetComponent<SpriteRenderer>();
        }
        public void SetupCardParameters( int cardsSuit, int numerals, Sprite appearance, Sprite backSideAppearance)
        {
            cardInfo = new CardsSettingSO(numerals, cardsSuit, appearance, backSideAppearance);
            StartVisualize();
        }
        public void TurnCard()
        {
            sprite.sprite = cardInfo.Appearance;
        }
        private void StartVisualize()
        {
            string cardName = new string($"{cardInfo.Numerals.ToString()} {cardInfo.CardsSuit.ToString()}"); 
            
            gameObject.name = cardName;
            sprite.sprite = cardInfo.BackSideAppearance;
        }
    }
}
