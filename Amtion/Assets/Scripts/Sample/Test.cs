using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Amtion;
using Amtion.Object;
using Amtion.Animation;

public class Test : AmtionScene
{
    public override void Start()
    {
        StartCoroutine(Scenes());
    }

    IEnumerator Scenes()
    {
        yield return new WaitForSeconds(1f);
        Am_Text text = new Am_Text("Hello world");
        this.FadeIn(text, 0.5f);
    }
}
