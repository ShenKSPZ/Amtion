using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class AmtionScene : MonoBehaviour
{
    public virtual void Start() { }

    public void Add(Am_Text Text)
    {
        if(Text.gameObject == null)
        {
            Text.gameObject = new GameObject(Text.DisplayText);
            Text.TextComponent = Text.gameObject.AddComponent<TextMeshPro>();
            Text.Initialize();
        }

        if(Text.TextComponent == null)
        {
            Text.TextComponent = Text.gameObject.AddComponent<TextMeshPro>();
            Text.Initialize();
        }
    }

    public void Play()
    {

    }
}
