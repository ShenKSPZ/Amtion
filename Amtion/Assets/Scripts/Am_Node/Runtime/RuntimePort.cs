using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Framework;

namespace Amtion.Node.Runtime
{
    public class RuntimePort : MonoBehaviour
    {
        public PortBase Base;
        public Text text;

        public void Load(PortBase port)
        {
            //Set current base
            Base = port == null ? Base : port;

            //Set Text
            text.text = port.Text;
        }

        public void Connect()
        {
            for (int i = 0; i < Base.ConnectPortID.Count; i++)
            {
                DrawConnectLine(this, RuntimeGraph.I().Ports[Base.ConnectPortID[i]]);
            }
        }

        public void DrawConnectLine(RuntimePort A, RuntimePort B)
        {
            CachePool.I().GetObject("Prefabs/Line", (obj) =>
            {
                obj.transform.SetParent(RuntimeGraph.I().LineGroup, false);
                RuntimeLine line = obj.GetComponent<RuntimeLine>();
                line.Draw(A, B);
            });
        }
    }
}