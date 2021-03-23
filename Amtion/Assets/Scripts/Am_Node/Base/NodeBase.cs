using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NodeBase
{
    public int[] NodePosition = new int[] { 0, 0 };
    public string UID = string.Empty;
    public string Label = string.Empty;
    public List<PortBase> InputPorts = new List<PortBase>();
    public List<PortBase> OutputPorts = new List<PortBase>();
    public List<string> ShowedPropertiesList = new List<string>();

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