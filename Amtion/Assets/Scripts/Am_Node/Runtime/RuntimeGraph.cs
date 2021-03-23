using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Framework;
using Amtion;
using System;
using System.Reflection;
using System.Linq;
using UnityEngine.Events;

namespace Amtion.Node.Runtime {
    public class RuntimeGraph : SingletonBaseDestory<RuntimeGraph>
    {
        public GraphBase graph;
        public RectTransform Pivot;
        public RectTransform NodeGroup;
        public RectTransform LineGroup;
        public RuntimeRightClickContextMenu RCMenu;

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
            AddRightClickMenu();
        }

        public void AddRightClickMenu()
        {
            MenuItem Main = new MenuItem();
            Main.name = "Main";

            MenuItem Obj = GenItem("Amtion.Object");

            MenuItem Anim = GenItem("Amtion.Animation");

            Main.SubItems.Add(Obj);
            Main.SubItems.Add(Anim);
            RCMenu.OverrideMenu(Main);
            print(typeof(Object.Am_Text).Namespace);
        }

        public MenuItem GenItem(string NameSpace)
        {
            Type[] objects = GetTypesInNamespace(Assembly.GetExecutingAssembly(), NameSpace);
            MenuItem menu = new MenuItem();
            menu.name = NameSpace.Split('.')[1];
            Dictionary<string, UnityAction> Items = new Dictionary<string, UnityAction>();
            for (int i = 0; i < objects.Length; i++)
            {
                Type temp = objects[i];
                Items.Add(temp.Name, () => { AddNode(Type.GetType(temp.Name + "_Node, Amtion.Node")); });
            }

            menu.ActualItem.Clear();
            menu.ActualItem = Items;
            return menu;
        }

        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .ToArray();
        }

        public void AddNode(Type type)
        {
            NodeBase node = (NodeBase)Activator.CreateInstance(type);
            node.Init();
            graph.Node.Add(node);
        } 

        public void AddNode<T>() where T : NodeBase, new()
        {
            NodeBase node = new T();
            node.Init();
            graph.Node.Add(node);
            //Load();
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
}