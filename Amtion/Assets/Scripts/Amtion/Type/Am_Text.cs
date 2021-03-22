using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Am_Text : TypeBase
{
    public GameObject gameObject;
    public TMP_Text TextComponent;
    public Transform transform
    {
        get { return gameObject.transform; }
    }

    public string DisplayText;
    public TMP_FontAsset Font;
    public int Size;
    public bool Bold;
    public bool Italic;
    public bool Underline;
    public bool Strike;
    public bool Highlight;
    public bool LowerCase;
    public bool UpperCase;
    public bool Subscript;
    public bool Superscript;
    public Color color;
    public VertexGradient gradient;

    public Am_Text(string DisplayText, 
        TMP_FontAsset Font = null, 
        int Size = 24, 
        bool Bold = false, bool Italic = false, bool Underline = false, bool Strike = false, bool Highlight = false, bool LowerCase = false, bool UpperCase = false, bool Subscript = false, bool Superscript = false,
        Color color = default, VertexGradient gradient = default)
    {
        this.DisplayText = DisplayText;
        this.Font = Font;
        this.Size = Size;
        this.Bold = Bold;
        this.Italic = Italic;
        this.Underline = Underline;
        this.Strike= Strike;
        this.Highlight = Highlight;
        this.LowerCase = LowerCase;
        this.UpperCase = UpperCase;
        this.Subscript = Subscript;
        this.Superscript = Superscript;
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

        TextComponent.text = DisplayText;
        if(Font != null)
            TextComponent.font = Font;
        TextComponent.fontSize = Size;
        TextComponent.fontStyle =
            (Bold ? FontStyles.Bold : 0) |
            (Italic ? FontStyles.Italic : 0) |
            (Underline ? FontStyles.Underline : 0) |
            (Strike ? FontStyles.Strikethrough : 0) |
            (Highlight ? FontStyles.Highlight : 0) |
            (LowerCase ? FontStyles.LowerCase : 0) |
            (UpperCase ? FontStyles.UpperCase : 0) |
            (Subscript ? FontStyles.Subscript : 0) |
            (Superscript ? FontStyles.Superscript : 0);

        if(color != default)
            TextComponent.color = color;

        TextComponent.colorGradient = gradient;
    }
}
