using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vector4Inputer : MonoBehaviour
{
    public InputField X;
    public InputField Y;
    public InputField Z;
    public InputField W;

    public Vector4 GetValue()
    {
        return new Vector4(float.Parse(X.text), float.Parse(Y.text), float.Parse(Z.text), float.Parse(W.text));
    }

    public Quaternion GetValue_Quaternion()
    {
        return new Quaternion(float.Parse(X.text), float.Parse(Y.text), float.Parse(Z.text), float.Parse(W.text));
    }

    public void SetValue(Vector4 v4)
    {
        X.text = v4.x.ToString();
        Y.text = v4.y.ToString();
        Z.text = v4.z.ToString();
        W.text = v4.w.ToString();
    }

    public void SetValue(Quaternion v4)
    {
        X.text = v4.x.ToString();
        Y.text = v4.y.ToString();
        Z.text = v4.z.ToString();
        W.text = v4.w.ToString();
    }
}
