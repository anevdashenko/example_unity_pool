using System;
using UnityEngine;

namespace _App.Scripts.Core.Entities.common
{
    [Serializable]
    public class MinMaxValue
    {
        public float Min;
        public float Max;

        public float GetLinearValue(float t)
        {
            return Mathf.Lerp(Min, Max, Mathf.Clamp01(t));
        }
    }
}