using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FunctionExtend;

namespace Amtion.Node
{
    public class StartNode : NodeBase
    {
        public override void Init()
        {
            base.Init();
            Label = "Start Node";
            NodePosition = new SVector2(960, 540);
            OutputPorts.Add(new PortBase()
            {
                Text = "Start",
                type = typeof(Object.Am_Text).ToString()
            }.Init());
        }
    }

}