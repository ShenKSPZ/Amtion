using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntInputer : MonoBehaviour
{
    public InputField Value;

    public int GetValue()
    {
        return int.Parse(Value.text);
    }

    public void SetValue(int value)
    {
        Value.text = value.ToString();
    }
}
