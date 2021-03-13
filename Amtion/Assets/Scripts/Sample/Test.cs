using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : AmtionScene
{
    public override void Start()
    {
        
    }

    IEnumerator Scenes()
    {
        yield return null;
        Am_Text text = new Am_Text("Hello world");
        Add(text);
    }
}
