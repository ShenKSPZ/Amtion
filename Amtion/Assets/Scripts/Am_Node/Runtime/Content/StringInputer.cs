using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StringInputer : MonoBehaviour
{
    public InputField Value;

    public string GetValue()
    {
        return Value.text;
    }

    public void SetValue(string value)
    {
        Value.text = value;
    }
}
