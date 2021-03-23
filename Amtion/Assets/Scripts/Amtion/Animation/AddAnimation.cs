using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Amtion.Object;

namespace Amtion.Animation
{
    public static class AddAnimation
    {
        public static void FadeIn(this AmtionScene scene, Am_Text text, float duration)
        {
            if (text.gameObject == null || text.TextComponent == null)
                scene.Add(text);
            Color Trans = new Color(text.TextComponent.color.r, text.TextComponent.color.g, text.TextComponent.color.b, 0);
            Color Final = new Color(text.TextComponent.color.r, text.TextComponent.color.g, text.TextComponent.color.b, text.TextComponent.color.a);
            text.TextComponent.color = Trans;
            text.TextComponent.DOColor(Final, duration);
        }
    }
}