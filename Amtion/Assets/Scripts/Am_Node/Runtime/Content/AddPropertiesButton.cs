using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPropertiesButton : MonoBehaviour
{
    public void AddProperties()
    {
        transform.GetComponentInParent<RuntimeNode>().AddProperties();
    }
}
