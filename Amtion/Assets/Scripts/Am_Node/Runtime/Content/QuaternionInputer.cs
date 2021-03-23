using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuaternionInputer : Inputer
{
    public Text Label;
    public InputField X;
    public InputField Y;
    public InputField Z;
    public InputField W;

    public override object GetValue()
    {
        return new Quaternion(float.Parse(X.text), float.Parse(Y.text), float.Parse(Z.text), float.Parse(W.text));
    }

    public override void SetValue(object value)
    {
        if(value is Vector4)
        {
            Vector4 ve = (Vector4)value;
            X.text = ve.x.ToString();
            Y.text = ve.y.ToString();
            Z.text = ve.z.ToString();
            W.text = ve.w.ToString();
        }
        else if(value is Quaternion)
        {
            Quaternion qu = (Quaternion)value;
            X.text = qu.x.ToString();
            Y.text = qu.y.ToString();
            Z.text = qu.z.ToString();
            W.text = qu.w.ToString();
        }
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
