using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game.UI
{
    public class InformPanelController : MonoBehaviour
    {
        [SerializeField] private TMP_Text headerText;
        [SerializeField] private Button newGameButton;
        [Header("Button Color")]
        [SerializeField] private Color winButtonColor;
        [SerializeField] private Color lostButtonColor;

        private RectTransform myTransform;
        private Image buttonImage;
        private Vector2 UI_START_POSITION; 
        private Vector2 UI_FINISH_POSITION; 

        private void Awake()
        {
            UI_START_POSITION = new Vector2(0f,1000f);
            UI_FINISH_POSITION = new Vector2(0f, 50f);


            myTransform = gameObject.GetComponent<RectTransform>();
            buttonImage = newGameButton.GetComponent<Image>();

            myTransform.anchoredPosition = new Vector2(0f, 1000f);
        }

        private void Start()
        {

            GameEventManager.Instance.OnPlayerWin.AddListener(OnPlayerWin);
            GameEventManager.Instance.OnNPCWin.AddListener(OnNPCWinWin);
            GameEventManager.Instance.OnDraw.AddListener(OnGameDraw);

            newGameButton.onClick.AddListener(RestartLevel);
        }
        private void OnNPCWinWin()
        {
            ChangeUIParameter("You lost!", lostButtonColor);
        }
        private void OnPlayerWin()
        {
            ChangeUIParameter("You win!", winButtonColor);
        }
        private void OnGameDraw()
        {
            ChangeUIParameter("Game is Draw!", lostButtonColor);
        }
        private void ChangeUIParameter(string line, Color buttonColor)
        {
            headerText.text = line.ToUpper();
            buttonImage.color = buttonColor;

            myTransform.DOAnchorPos(UI_FINISH_POSITION, 1f);
        }
        private void RestartLevel()
        {
            GameEventManager.Instance.OnLoadMenuOpened.Invoke();
            Invoke("DelayedRestart", 1.5f);
        }
        private void DelayedRestart()
        {
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.buildIndex);
        }
    }
}
