using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoolInputer : MonoBehaviour
{
    public Toggle Value;

    public bool GetValue()
    {
        return Value.isOn;
    }

    public void GetValue(bool value)
    {
        Value.isOn = value;
    }
}
