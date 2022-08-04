using System.Collections;
using UnityEngine;
using Game;

namespace Cards.Game.Input
{
    [RequireComponent(typeof(NPCCardsRepository))]
    [RequireComponent(typeof(NPCCardPrice))]
    public class NPCInput : CustomInputSystem
    {
        private NPCCardsRepository npcCardsRepository;
        private NPCCardPrice npcCardPrice;
        private UINPCScoreController uiNpsScore;
        private void Awake()
        {
            npcCardsRepository = gameObject.GetComponent<NPCCardsRepository>();
            npcCardPrice = gameObject.GetComponent<NPCCardPrice>();
            uiNpsScore = gameObject.GetComponent<UINPCScoreController>();
        }
        private void Start()
        {
            GameEventManager.Instance.OnNPCTurn.AddListener(NPCTurn);
        }
        public override void Enough()
        {
            StopAllCoroutines();
            StartCoroutine(TurnNPCCards());
        }

        public override void TakeMore()
        {
            npcCardsRepository.AddCardToPull(GameCardsRepository.Instance.GetRandomCard());
            GameEventManager.Instance.OnCardSound.Invoke();
        }

        private void NPCTurn()
        {
            StartCoroutine(Step());
        }
        IEnumerator Step()
        {
            int coefficient = 4;
            while(true)
            {
                int cardPullCount = npcCardPrice.PriceValue * coefficient;
                yield return new WaitForSeconds(1f);
                if(npcCardPrice.PriceValue < Random.Range(14,17))
                {
                    TakeMore();
                }
                else
                {
                    if(Random.Range(0, 100) > cardPullCount)
                    {
                        TakeMore();
                    }
                    else Enough();
                }
            }
        }
        IEnumerator TurnNPCCards()
        {
            for(int i = 0; i < npcCardsRepository.CardsPull.Count; i++)
            {
                npcCardsRepository.CardsPull[i].GetComponent<CardSetting>().TurnCard();
                GameEventManager.Instance.OnCardSound.Invoke();
                yield return new WaitForSeconds(0.5f);
            }
            GameEventManager.Instance.OnNPCFInish.Invoke();
            uiNpsScore.UpdateScoreTextValue(npcCardPrice.PriceValue);
            
        }
    }
}
