using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntRange : Inputer
{
    public Text Label;
    public Slider range;

    public override object GetValue()
    {
        return Mathf.FloorToInt(range.value);
    }

    public override void SetValue(object value)
    {
        range.value = (int)value;
    }

    public void SetRange(float min, float max)
    {
        range.minValue = min;
        range.maxValue = max;
    }

    public override void SetLabel(string value)
    {
        Label.text = value;
    }

    public override string GetLabel()
    {
        return Label.text;
    }
}
