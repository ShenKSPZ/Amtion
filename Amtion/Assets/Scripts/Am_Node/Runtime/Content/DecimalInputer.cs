using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecimalInputer : MonoBehaviour
{
    public InputField Value;

    public double GetValue()
    {
        return float.Parse(Value.text);
    }

    public void SetValue(float value)
    {
        Value.text = value.ToString();
    }
}
