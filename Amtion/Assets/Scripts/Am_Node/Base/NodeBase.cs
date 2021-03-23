using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Amtion.Node
{
    [Serializable]
    public class NodeBase
    {
        [HideField]
        public int[] NodePosition = new int[] { 0, 0 };
        [HideField]
        public string UID = string.Empty;
        [HideField]
        public string Label = string.Empty;
        [HideField]
        public List<PortBase> InputPorts = new List<PortBase>();
        [HideField]
        public List<PortBase> OutputPorts = new List<PortBase>();
        [HideField]
        public List<string> ShowedPropertiesList = new List<string>();
        [HideField]
        public Dictionary<string, UnityAction> ContextMenu = new Dictionary<string, UnityAction>();

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
}