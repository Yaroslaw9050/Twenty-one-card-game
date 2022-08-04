using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards.Game.Input
{
    public abstract class CustomInputSystem : MonoBehaviour
    {
        public abstract void TakeMore();
        public abstract void Enough();
    }
}
