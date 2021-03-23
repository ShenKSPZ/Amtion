using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RuntimeRightClickContextMenu : MonoBehaviour
{

    public Text Label;

    public MenuItem Item = new MenuItem();

    public void OverrideMenu(MenuItem Item)
    {

    }
}

[System.Serializable]
public class MenuItem
{
    public string name;
    public List<MenuItem> SubItems = new List<MenuItem>();
    public Dictionary<string, UnityAction> ActualItem = new Dictionary<string, UnityAction>();
}