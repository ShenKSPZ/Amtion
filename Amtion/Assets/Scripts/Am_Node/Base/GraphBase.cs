using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Amtion.Node
{
    [System.Serializable]
    public class GraphBase
    {
        public string GraphName = "New_Graph";
        public List<NodeBase> Node = new List<NodeBase>();
    }
}