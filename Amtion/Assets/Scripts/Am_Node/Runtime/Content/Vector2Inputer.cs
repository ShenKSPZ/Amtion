using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vector2Inputer : MonoBehaviour
{
    public InputField X;
    public InputField Y;

    public Vector2 GetValue()
    {
        return new Vector2(float.Parse(X.text), float.Parse(Y.text));
    }

    public void SetValue(Vector2 v2)
    {
        X.text = v2.x.ToString();
        Y.text = v2.y.ToString();
    }
}
