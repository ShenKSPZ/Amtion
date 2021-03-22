using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Framework;

public class RuntimeNode : MonoBehaviour
{
    public NodeBase Base;
    public Text Label;
    public RectTransform InputParent;
    public RectTransform OutputParent;
    public RectTransform ContentParent;

    #region Ports
    List<RuntimePort> InputPorts;
    List<RuntimePort> OutputPorts;
    #endregion

    public void Load(NodeBase node = null)
    {
        //Set current base
        Base = node == null ? Base : node;

        //Set position
        transform.localPosition = new Vector3(Base.Position[0], Base.Position[1]);

        //Set label
        Label.text = Base.Label;

        //Set Input ports
        for (int i = 0; i < Base.InputPorts.Count; i++)
        {
            CachePool.I().GetObject("Prefabs/InputPort", (obj) => 
            {
                obj.transform.SetParent(InputParent, false);
                RuntimePort rp = obj.GetComponent<RuntimePort>();
                rp.Load(Base.InputPorts[i]);
                InputPorts.Add(rp);
                RuntimeGraph.I().Ports.Add(rp.Base.UID, rp);
            });
        }

        //Set Output ports
        for (int i = 0; i < Base.OutputPorts.Count; i++)
        {
            CachePool.I().GetObject("Prefabs/OutputPort", (obj) =>
            {
                obj.transform.SetParent(OutputParent, false);
                RuntimePort rp = obj.GetComponent<RuntimePort>();
                rp.Load(Base.OutputPorts[i]);
                OutputPorts.Add(rp);
                RuntimeGraph.I().Ports.Add(rp.Base.UID, rp);
            });
        }

        //Set Content
        for (int i = 0; i < Base.Content.Count; i++)
        {
            GameObject obj = Base.Content[i].Load();
            if(obj != null)
            {
                obj.transform.SetParent(ContentParent, false);
            }
        }
    }

    public void Connect()
    {
        //Set Connect (Only need to go over all InputPorts. )
        for (int i = 0; i < InputPorts.Count; i++)
        {
            InputPorts[i].Connect();
        }
    }

    public void AddProperties()
    {

    }
}
