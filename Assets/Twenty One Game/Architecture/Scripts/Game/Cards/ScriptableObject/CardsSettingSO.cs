using Cards.Enum;
using UnityEngine;

namespace CustomSO
{
    [CreateAssetMenu(fileName = "CardsSettingSO", menuName = "Cards")]
    public class CardsSettingSO : ScriptableObject
    {
        [Header("Card Type")]
        [SerializeField] private Numerals numerals;
        [SerializeField] private CardsSuit cardsSuit;
        [Header("Visual")]
        [SerializeField] private Sprite appearance;
        [SerializeField] private Sprite backSideAppearance;
        public Sprite Appearance
        {
            get { return appearance;}
        }
        public Sprite BackSideAppearance
        {
            get { return backSideAppearance;}
        }
        public CardsSuit CardsSuit
        {
            get { return cardsSuit;}
        }
        public Numerals Numerals
        {
            get { return numerals;}
        }
        

        public CardsSettingSO(int numerals, int cardsSuit, Sprite appearance, Sprite backSideAppearance)
        {
            this.numerals = (Numerals) numerals;
            this.cardsSuit = (CardsSuit) cardsSuit;
            this.appearance = appearance;
            this.backSideAppearance = backSideAppearance;
        }
    }
}