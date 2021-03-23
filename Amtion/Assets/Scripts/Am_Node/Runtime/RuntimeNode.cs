using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
    List<RuntimePort> InputPorts = new List<RuntimePort>();
    List<RuntimePort> OutputPorts = new List<RuntimePort>();
    Dictionary<string, Inputer> BaseInputer = new Dictionary<string, Inputer>();
    #endregion

    #region BasicType
    System.Type stringType = typeof(string);
    System.Type intType = typeof(int);
    System.Type floatType = typeof(float);
    System.Type Vector2Type = typeof(Vector2);
    System.Type Vector3Type = typeof(Vector3);
    System.Type Vector4Type = typeof(Vector4);
    System.Type QuaternionType = typeof(Quaternion);
    System.Type boolType = typeof(bool);
    System.Type enumType = typeof(System.Enum);
    #endregion

    public void Load(NodeBase node = null)
    {
        //Set current base
        Base = node != null ? node : Base;

        //Set position
        transform.localPosition = new Vector3(Base.NodePosition[0], Base.NodePosition[1]);

        //Set label
        Label.text = Base.Label;

        #region Set Input ports
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
        #endregion

        #region Set Output ports
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
        #endregion

        #region Set Content
        System.Type t = Base.GetType();
        FieldInfo[] info = t.GetFields();

        int ContentCounter = 0;
        int FieldsCount = 0;

        for (int i = 0; i < info.Length; i++)
        {
            if(info[i].Name == "NodePosition" || 
                info[i].Name == "UID" || 
                info[i].Name == "Label")
            {
                continue;
            }

            FieldsCount++;

            if (!Base.ShowedPropertiesList.Contains(info[i].Name))
                continue;

            ContentCounter++;

            System.Type CurType = info[i].FieldType;
            if(CurType == stringType)
            {
                TextAreaAttribute att = (TextAreaAttribute)info[i].GetCustomAttribute(typeof(TextAreaAttribute), false);
                if(att == null)
                    GetInputer("String", info[i].Name, info[i].GetValue(Base));
                else
                    GetInputer("StringMultiline", info[i].Name, info[i].GetValue(Base));
            }
            else if(CurType == intType)
            {
                RangeAttribute att = (RangeAttribute)info[i].GetCustomAttribute(typeof(RangeAttribute), false);
                if(att == null)
                    GetInputer("Int", info[i].Name, info[i].GetValue(Base));
                else
                {
                    CachePool.I().GetObject("Prefabs/Content/Int_Range", (obj) =>
                    {
                        obj.transform.SetParent(ContentParent, false);
                        IntRange inputer = obj.GetComponent<IntRange>();
                        inputer.SetLabel(info[i].Name);
                        inputer.SetValue(info[i].GetValue(Base));
                        inputer.SetRange(att.min, att.max);
                        BaseInputer.Add(info[i].Name, inputer);
                    });
                }
            }
            else if (CurType == floatType)
            {
                RangeAttribute att = (RangeAttribute)info[i].GetCustomAttribute(typeof(RangeAttribute), false);
                if(att == null)
                    GetInputer("Decimal", info[i].Name, info[i].GetValue(Base));
                else
                {
                    CachePool.I().GetObject("Prefabs/Content/Decimal_Range", (obj) =>
                    {
                        obj.transform.SetParent(ContentParent, false);
                        DecimalRange inputer = obj.GetComponent<DecimalRange>();
                        inputer.SetLabel(info[i].Name);
                        inputer.SetValue(info[i].GetValue(Base));
                        inputer.SetRange(att.min, att.max);
                        BaseInputer.Add(info[i].Name, inputer);
                    });
                }
            }
            else if (CurType == Vector2Type)
            {
                GetInputer("Vector2", info[i].Name, info[i].GetValue(Base));
            }
            else if (CurType == Vector3Type)
            {
                GetInputer("Vector3", info[i].Name, info[i].GetValue(Base));
            }
            else if (CurType == Vector4Type)
            {
                GetInputer("Vector4", info[i].Name, info[i].GetValue(Base));
            }
            else if (CurType == QuaternionType)
            {
                GetInputer("Vector4", info[i].Name, info[i].GetValue(Base));
            }
            else if (CurType == boolType)
            {
                GetInputer("Toggle", info[i].Name, info[i].GetValue(Base));
            }
            else if (CurType == enumType)
            {
                GetInputer("Dropdown", info[i].Name, info[i].GetValue(Base));
                CachePool.I().GetObject("Prefabs/Content/Dropdown", (obj) =>
                {
                    obj.transform.SetParent(ContentParent, false);
                    DropdownMenu inputer = obj.GetComponent<DropdownMenu>();
                    object temp = info[i].GetValue(Base);
                    inputer.SetEnum(info[i].FieldType);
                    inputer.SetLabel(info[i].Name);
                    inputer.SetValue(temp);
                    BaseInputer.Add(info[i].Name, inputer);
                });
            }
        }
        #endregion

        #region Set Add Button
        if(ContentCounter < FieldsCount)
            CachePool.I().GetObject("Prefabs/Content/AddButton", (obj) =>
            {
                obj.transform.SetParent(ContentParent, false);
            });
        #endregion
    }

    public void GetInputer(string Type, string Name, object Value)
    {
        CachePool.I().GetObject("Prefabs/Content/" + Type, (obj) =>
        {
            obj.transform.SetParent(ContentParent, false);
            Inputer inputer = obj.GetComponent<Inputer>();
            inputer.SetLabel(Name);
            inputer.SetValue(Value);
            BaseInputer.Add(Name, inputer);
        });
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
