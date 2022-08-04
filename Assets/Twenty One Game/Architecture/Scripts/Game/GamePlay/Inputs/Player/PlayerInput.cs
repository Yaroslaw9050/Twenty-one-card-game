using UnityEngine;
using Cards.Game;
using UnityEngine.UI;
using TMPro;
using Game;

namespace Cards.Game.Input
{
    [RequireComponent(typeof(PlayerCardsRepository))]
    public class PlayerInput : CustomInputSystem
    {
        private static string TAKE_MORE_BUTTON_NAME = "TakeMoreButton";
        private static string ENOUGH_BUTTON_NAME = "EnoughButton";
        private Button takeMore;
        private Button enought;
        private PlayerCardsRepository repository;

        private void Awake()
        {
            takeMore = GameObject.Find(TAKE_MORE_BUTTON_NAME).GetComponent<Button>();
            enought = GameObject.Find(ENOUGH_BUTTON_NAME).GetComponent<Button>();

            takeMore.onClick.AddListener(TakeMore);
            enought.onClick.AddListener(Enough);

            repository = gameObject.GetComponent<PlayerCardsRepository>();
        }
        private void Start()
        {
            GameEventManager.Instance.OnNPCWin.AddListener(ChangePickUpPossibility);
            GameEventManager.Instance.OnPlayerWin.AddListener(ChangePickUpPossibility);
        }
        public override void Enough()
        {
            GameEventManager.Instance.OnNPCTurn.Invoke();
            ChangePickUpPossibility();
        }

        public override void TakeMore()
        {
            repository.AddCardToPull(GameCardsRepository.Instance.GetRandomCard());
            GameEventManager.Instance.OnCardSound.Invoke();
        }

        private void ChangePickUpPossibility()
        {
            takeMore.interactable = false;
            enought.interactable = false;
        } 
    }
}
