using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RightClickMenuItem : MonoBehaviour
{

    public Text label;
    public UnityAction Action;

    public void SetLabel(string value)
    {
        label.text = value;
    }

    public void AddAction(UnityAction action)
    {
        Action += action;
    }

    public void CallAction()
    {
        Action?.Invoke();
    }
}
