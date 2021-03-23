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
    public List<RuntimeNode> Nodes = new List<RuntimeNode>();
    [HideInInspector]
    public Dictionary<string, RuntimePort> Ports = new Dictionary<string, RuntimePort>();
    [HideInInspector]
    public List<RuntimeLine> Lines = new List<RuntimeLine>();

    [HideInInspector]
    public bool Saving = false;
    #endregion

    private void Start()
    {
        AddNode<StartNode>();
    }

    public void AddNode<T>()where T : NodeBase, new()
    {
        T node = new T();
        node.Init();
        graph.Node.Add(node);
        Load();
    }

    public void Load(GraphBase newGraph = null)
    {
        graph = newGraph != null ? newGraph : graph;

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
        FileOPS.SaveJson(Application.streamingAssetsPath, graph.GraphName, graph);
    }

    public void Save(string path, string name)
    {
        if (graph == null)
            return;
        graph.GraphName = name;
        FileOPS.SaveJson(path, graph.GraphName, graph);
    }

}
