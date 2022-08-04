using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;

public class UINPCScoreController : UIScoreController
{
    public override void Awake()
    {
        SCORE_TEXT_NAME = "NPCCardValueText";
        base.Awake();
    }
}
