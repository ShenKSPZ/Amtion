using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoolInputer : Inputer
{
    public Text Label;
    public Toggle Value;

    public override object GetValue()
    {
        return Value.isOn;
    }

    public override void SetValue(object value)
    {
        Value.isOn = (bool)value;
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
