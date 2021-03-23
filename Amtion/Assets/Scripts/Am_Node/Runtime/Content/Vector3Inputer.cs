using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vector3Inputer : Inputer
{
    public Text Label;
    public InputField X;
    public InputField Y;
    public InputField Z;

    public override object GetValue()
    {
        return new Vector3(float.Parse(X.text), float.Parse(Y.text), float.Parse(Z.text));
    }

    public override void SetValue(object v3)
    {
        Vector3 ve = (Vector3)v3;
        X.text = ve.x.ToString();
        Y.text = ve.y.ToString();
        Z.text = ve.z.ToString();
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
