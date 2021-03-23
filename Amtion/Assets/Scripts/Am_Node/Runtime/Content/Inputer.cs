using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputer : MonoBehaviour
{
    public virtual object GetValue()
    {
        return null;
    }

    public virtual void SetValue(object value)
    {

    }

    public virtual string GetLabel()
    {
        return string.Empty;
    }

    public virtual void SetLabel(string value)
    {

    }
}
