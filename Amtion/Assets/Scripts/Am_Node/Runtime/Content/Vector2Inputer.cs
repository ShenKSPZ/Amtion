using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vector2Inputer : Inputer
{
    public Text Label;
    public InputField X;
    public InputField Y;

    public override object GetValue()
    {
        return new Vector2(float.Parse(X.text), float.Parse(Y.text));
    }

    public override void SetValue(object v2)
    {
        Vector2 ve = (Vector2)v2;
        X.text = ve.x.ToString();
        Y.text = ve.y.ToString();
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
