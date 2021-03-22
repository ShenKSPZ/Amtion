using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NodeBase
{
    public int[] Position = new int[] { 0, 0 };
    public string UID;
    public string Label;
    public List<PortBase> InputPorts;
    public List<PortBase> OutputPorts;
    public List<NodeContentBase> Content;

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