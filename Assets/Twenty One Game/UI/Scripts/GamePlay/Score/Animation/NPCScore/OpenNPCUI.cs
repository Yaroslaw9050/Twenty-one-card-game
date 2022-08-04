using UnityEngine;
using DG.Tweening;

namespace Game.UI.NPC
{
    public class OpenNPCUI : MonoBehaviour
    {
        private void Start()
        {
            GameEventManager.Instance.OnNPCFInish.AddListener(OpenUI);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f,80f);
        }
        private void OpenUI()
        {
            gameObject.GetComponent<RectTransform>().DOAnchorPosY(0f, 0.5f);
        }
    }
}
