using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.UI
{
    public class UIScoreController : MonoBehaviour
    {
        protected static string SCORE_TEXT_NAME = "";
        protected TMP_Text scoreText;

        public virtual void Awake()
        {
            scoreText = GameObject.Find(SCORE_TEXT_NAME).GetComponent<TMP_Text>();
        }
        public virtual void UpdateScoreTextValue(int value)
        {
            scoreText.text = $"{value} / 21";
        }
    }
}
