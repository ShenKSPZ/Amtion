using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : NodeBase
{
    public override void Init()
    {
        base.Init();
        Label = "Start Node";
        NodePosition = new int[] { 960, 540 };
        OutputPorts.Add(new PortBase()
        {
            Text = "Start",
            type = typeof(Amtion).ToString()
        }.Init());
    }
}
