using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageControl : MonoBehaviour
{
    public RawImage Image;

    public void SetImage(Texture texture)
    {
        Image.texture = texture;
    }
}
