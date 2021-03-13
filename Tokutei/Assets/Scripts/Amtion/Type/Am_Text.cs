using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Am_Text
{
    public GameObject gameObject;
    public TMP_Text TextComponent;

    public string DisplayText;
    public string Fonts;
    public int Size;
    public bool Bold;
    public bool Italic;
    public bool Underline;
    public bool Strike;
    public Color color;
    public VertexGradient gradient;

    public Am_Text(string DisplayText, string Fonts = "", int Size = 0, bool Bold = false, bool Italic = false, bool Underline = false, bool Strike = false, Color color = default, VertexGradient gradient = default)
    {
        this.DisplayText = DisplayText;
        this.Fonts = Fonts;
        this.Size = Size;
        this.Bold = Bold;
        this.Italic = Italic;
        this.Underline = Underline;
        this.Strike= Strike;
        this.color = color;
        this.gradient = gradient;
    }

    public void Initialize()
    {
        if(gameObject == null || TextComponent == null)
        {
            Debug.LogError("Please use <b>AmtionScene.Add()</b> or <b>AmtionScene.Play()</b> to let this object Initialize. Don't call this function youself");
            return;
        }

    }
}
