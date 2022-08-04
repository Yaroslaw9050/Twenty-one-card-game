using UnityEngine;


namespace Cards.Game
{
    public abstract class CardScriptAnimation : MonoBehaviour
    {
        public abstract void MoveCardTo();

        public abstract void UpdateCardPosition();
    }
}
