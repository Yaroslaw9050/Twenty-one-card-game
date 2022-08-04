using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;

public class UIPlayerScoreController : UIScoreController
{
    public override void Awake()
    {
        SCORE_TEXT_NAME = "PlayerCardValueText";
        base.Awake();
    }
}
