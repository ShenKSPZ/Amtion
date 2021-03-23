using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Amtion.Node
{
    [System.Serializable]
    public class Am_Text_Node : NodeBase
    {

        public string Text = string.Empty;
        public Vector3 Fill_Color = Vector3.zero;

        public override void Init()
        {
            base.Init();
            Label = "Text Obj";
            NodePosition = new int[] { 960, 540 };

            InputPorts.Add(new PortBase()
            {
                Text = "Properties",
                type = typeof(Object.Am_Text).ToString()
            }.Init());

            OutputPorts.Add(new PortBase()
            {
                Text = "Out",
                type = typeof(Object.Am_Text).ToString()
            }.Init());

            ShowedPropertiesList.Add("Text");
            ShowedPropertiesList.Add("Fill_Color");
        }
    }
}