using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PortBase
{
    public string UID;
    public string type;
    public string Text;
    public List<string> ConnectPortID;

    public virtual void Init()
    {
        SetUID();
    }

    public void SetUID()
    {
        if (UID == string.Empty)
            UID = Guid.NewGuid().ToString();
    }

    public void ForceSetUID()
    {
        UID = Guid.NewGuid().ToString();
    }
}
