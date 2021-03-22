using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NodeContentBase
{
    public virtual GameObject Load()
    {
        return null;
    }

    public virtual void Init()
    {

    }
}
