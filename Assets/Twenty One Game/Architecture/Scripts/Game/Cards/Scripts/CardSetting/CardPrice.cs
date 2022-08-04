using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cards.Enum;

namespace Cards.Game
{
    public class CardPrice : MonoBehaviour
    {
        protected int priceValue;

        public virtual void TakeCardPrice(int numerals)
        {
            if(numerals < 11)
            {
                priceValue += numerals;
            }
            else priceValue += CompareValue(numerals);
        }

        private int CompareValue(int numerals)
        {
            switch(numerals)
                {
                    case 11: return 2;
                    case 12: return 3;
                    case 13: return 4;
                    case 14: return 11;
                    default: return 0;
                }
        }
    }
}
