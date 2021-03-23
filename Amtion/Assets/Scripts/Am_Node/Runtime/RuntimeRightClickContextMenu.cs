using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Framework;
using System.Text;

namespace Amtion.Node.Runtime
{
    public class RuntimeRightClickContextMenu : MonoBehaviour
    {

        public Text Label;

        public MenuItem Item = new MenuItem();

        public string Pointer = string.Empty;

        public void OverrideMenu(MenuItem item)
        {
            Item = item;
            Label.text += new StringBuilder("/").Append(item.name).ToString();
            NextMenu(item);
        }

        void NextMenu(MenuItem item)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                //TODO: Change to put object
                if(transform.GetChild(i).name != "Label")
                    Destroy(transform.GetChild(i).gameObject);
            }

            if (item.father != null)
            {
                CachePool.I().GetObject("Prefabs/Context/BackButton", (obj) =>
                {
                    obj.transform.SetParent(transform, false);
                    RightClickMenuItem rcItem = obj.GetComponent<RightClickMenuItem>();
                    MenuItem next = item;
                    rcItem.AddAction(() => {
                        Label.text = Label.text.Substring(0, Label.text.Length - new StringBuilder("/").Append(item.name).ToString().Length);
                        NextMenu(next.father);
                    });
                });
            }

            for (int i = 0; i < item.SubItems.Count; i++)
            {
                CachePool.I().GetObject("Prefabs/Context/ContextButton", (obj) =>
                {
                    obj.transform.SetParent(transform, false);
                    RightClickMenuItem rcItem = obj.GetComponent<RightClickMenuItem>();
                    rcItem.SetLabel(Item.SubItems[i].name);
                    MenuItem nextItem = Item.SubItems[i];
                    MenuItem cur = item;
                    rcItem.AddAction(() => {
                        nextItem.father = cur;
                        Label.text += new StringBuilder("/").Append(nextItem.name).ToString();
                        NextMenu(nextItem); 
                    });
                });
            }

            foreach (var key in item.ActualItem.Keys)
            {
                CachePool.I().GetObject("Prefabs/Context/ActualButton", (obj) =>
                {
                    obj.transform.SetParent(transform, false);
                    RightClickMenuItem rcItem = obj.GetComponent<RightClickMenuItem>();
                    rcItem.SetLabel(key);
                    rcItem.AddAction(item.ActualItem[key]);
                });
            }
        }
    }
}


[System.Serializable]
public class MenuItem
{
    public string name = string.Empty;
    public MenuItem father = null;
    public List<MenuItem> SubItems = new List<MenuItem>();
    public Dictionary<string, UnityAction> ActualItem = new Dictionary<string, UnityAction>();
}