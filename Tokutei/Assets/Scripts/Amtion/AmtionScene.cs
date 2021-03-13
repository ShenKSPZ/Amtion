using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmtionScene : MonoBehaviour
{
    public virtual void Start()
    {

    }

    public void Wait()
    {

    }

    public void Play()
    {

    }

    public void Add(Am_Text Text)
    {
        if(Text.gameObject == null)
        {
            Text.gameObject = new GameObject(Text.DisplayText);
            Text.TextComponent = Text.gameObject.AddComponent<TMP_Text>();
            Text.Initialize();
        }

        if(Text.TextComponent == null)
        {
            Text.TextComponent = Text.gameObject.AddComponent<TMP_Text>();
            Text.Initialize();
        }


    }
}
