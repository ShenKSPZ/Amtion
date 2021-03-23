using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecimalInputer : Inputer
{
    public Text Label;
    public InputField Value;

    public override object GetValue()
    {
        return float.Parse(Value.text);
    }

    public override void SetValue(object value)
    {
        Value.text = value.ToString();
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
