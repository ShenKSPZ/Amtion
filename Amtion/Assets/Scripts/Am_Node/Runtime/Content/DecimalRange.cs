using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecimalRange : MonoBehaviour
{
    public Slider range;

    public float GetValue()
    {
        return range.value;
    }

    public void SetValue(float value)
    {
        range.value = value;
    }

    public void SetRange(float min, float max)
    {
        range.minValue = min;
        range.maxValue = max;
    }
}
