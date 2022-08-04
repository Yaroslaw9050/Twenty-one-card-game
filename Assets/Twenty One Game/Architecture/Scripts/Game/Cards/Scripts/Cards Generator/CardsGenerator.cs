using UnityEngine;

namespace Cards.Game
{
    [RequireComponent(typeof(GameCardsRepository))]
    public class CardsGenerator : MonoBehaviour
    {
        [Header("Setting")]
        [SerializeField] private Transform transformSpawnPosition;
        [SerializeField] private Sprite backSideAppearance;
        [Header("Diamonds")]
        [SerializeField] private Sprite[] appearancesDiamonds;
        [Header("Hearts")]
        [SerializeField] private Sprite[] appearancesHearts;
        [Header("Clubs")]
        [SerializeField] private Sprite[] appearancesClubs;
        [Header("Spades")]
        [SerializeField] private Sprite[] appearancesSpades;
        private CardsRepository repository;
        private static string EMPTYCARD_PREFAB = "Prefabs/Cards/Empty_Card";

        private void Awake()
        {
            repository = gameObject.GetComponent<GameCardsRepository>();
        }
        private void Start()
        {
            GenerateCards(0,appearancesDiamonds);
            GenerateCards(1,appearancesHearts);
            GenerateCards(2,appearancesClubs);
            GenerateCards(3,appearancesSpades);
        }
        private void GenerateCards(int cardType, Sprite [] sprites)
        {
            Object emptyCardprefab = Resources.Load(EMPTYCARD_PREFAB, typeof(GameObject));
            GameObject card;

            for(int i = 0; i < sprites.Length; i++)
            {
                card = Instantiate(emptyCardprefab, transformSpawnPosition.position, Quaternion.identity) as GameObject;
                card.GetComponent<CardSetting>().SetupCardParameters(cardType,i + 2, sprites[i], backSideAppearance);
                card.transform.SetParent(transformSpawnPosition);
                repository.AddCardToPull(card);
            }
        }

    }
}
