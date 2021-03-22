using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntRange : MonoBehaviour
{

    public Slider range;

    public int GetValue()
    {
        return Mathf.FloorToInt(range.value);
    }

    public void SetValue(int value)
    {
        range.value = value;
    }

    public void SetRange(int min, int max)
    {
        range.minValue = min;
        range.maxValue = max;
    }
}
