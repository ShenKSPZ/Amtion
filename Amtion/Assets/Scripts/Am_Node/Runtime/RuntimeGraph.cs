using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Framework;

public class RuntimeGraph : SingletonBaseDestory<RuntimeGraph>
{
    public GraphBase graph;
    public RectTransform Pivot;
    public RectTransform NodeGroup;
    public RectTransform LineGroup;

    #region Runtime
    [HideInInspector]
    public List<RuntimeNode> Nodes;
    [HideInInspector]
    public Dictionary<string, RuntimePort> Ports;
    [HideInInspector]
    public List<RuntimeLine> Lines;

    [HideInInspector]
    public bool Saving = false;
    #endregion

    public void Load(GraphBase newGraph = null)
    {
        graph = newGraph == null ? graph : newGraph;

        StartCoroutine(IE_Load());
    }

    IEnumerator IE_Load()
    {
        //Load All Nodes
        for (int i = 0; i < graph.Node.Count; i++)
        {
            CachePool.I().GetObject("Prefabs/NodeBase", (obj) =>
            {
                obj.transform.SetParent(NodeGroup, false);
                RuntimeNode rnode = obj.GetComponent<RuntimeNode>();
                rnode.Load(graph.Node[i]);
                Nodes.Add(rnode);
            });
        }

        //Connect All Ports
        for (int i = 0; i < Nodes.Count; i++)
        {
            Nodes[i].Connect();
        }
        yield return null;
    }

    public void Save()
    {
        if (graph == null)
            return;
        StreamWriter sw = new StreamWriter(Path.Combine(Application.streamingAssetsPath, graph.GraphName));
        sw.Write(JsonConvert.SerializeObject(graph));
        sw.Close();
    }

    public void Save(string path)
    {
        if (graph == null)
            return;
        StreamWriter sw = new StreamWriter(path);
        sw.Write(JsonConvert.SerializeObject(graph));
        sw.Close();
    }

}
