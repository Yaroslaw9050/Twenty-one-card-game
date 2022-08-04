using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Game.UI
{
    public class LoadingPanelController : MonoBehaviour
    {
        [SerializeField] private GameObject loadingPanel;
        private Image mainPenalIMG;
        private Vector2 UI_START_POSITION; 
        private Vector2 UI_FINISH_POSITION; 

        private void Awake()
        {
            UI_START_POSITION = Vector2.zero;
            UI_FINISH_POSITION = new Vector2(3500f, 0f);

            mainPenalIMG = gameObject.GetComponent<Image>();
        }
        private void Start()
        {
            loadingPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);

            GameEventManager.Instance.OnLoadMenuOpened.AddListener(OpenLoadUI);
            GameEventManager.Instance.OnLoadMenuClosed.AddListener(CloseLoadUI);
        }
        private void OpenLoadUI()
        {
            mainPenalIMG.enabled = true;
            mainPenalIMG.DOColor(new Color(0f,0f,0f,0f), 0.5f);
            loadingPanel.GetComponent<RectTransform>().DOAnchorPos(UI_START_POSITION, 0.5f);
        }
        private void CloseLoadUI()
        {
            mainPenalIMG.color = new Color(0f,0f,0f,0f);
            mainPenalIMG.enabled = false;

            loadingPanel.GetComponent<RectTransform>().DOAnchorPos(UI_FINISH_POSITION, 0.5f);
        }
    }
}
