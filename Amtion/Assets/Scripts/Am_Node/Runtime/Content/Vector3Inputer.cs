using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vector3Inputer : MonoBehaviour
{
    public InputField X;
    public InputField Y;
    public InputField Z;

    public Vector3 GetValue()
    {
        return new Vector3(float.Parse(X.text), float.Parse(Y.text), float.Parse(Z.text));
    }

    public void SetValue(Vector3 v3)
    {
        X.text = v3.x.ToString();
        Y.text = v3.y.ToString();
        Z.text = v3.z.ToString();
    }
}
