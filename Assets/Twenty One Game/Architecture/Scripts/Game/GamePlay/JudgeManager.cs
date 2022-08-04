using UnityEngine;
using Cards.Game;

namespace Game
{
    public class JudgeManager : MonoBehaviour
    {
        [SerializeField] private PlayerCardPrice playerCardPrice;
        [SerializeField] private NPCCardPrice npcCardPrice;
        private void Start()
        {
            GameEventManager.Instance.OnNPCFInish.AddListener(Judge);
        }

        private void Judge()
        {
            if(playerCardPrice.PriceValue < 22 && npcCardPrice.PriceValue < 22)
            {
                if(playerCardPrice.PriceValue > npcCardPrice.PriceValue)
                        GameEventManager.Instance.OnPlayerWin.Invoke();

                else if(playerCardPrice.PriceValue == npcCardPrice.PriceValue)
                        GameEventManager.Instance.OnDraw.Invoke();

                else GameEventManager.Instance.OnNPCWin.Invoke();
            }
            else
            {
                GameEventManager.Instance.OnPlayerWin.Invoke();
            }
        }
    }
}
