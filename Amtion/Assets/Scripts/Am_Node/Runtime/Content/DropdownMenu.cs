using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownMenu : Inputer
{
    public Text Label;
    public Dropdown dropdown;
    public System.Type EnumType;

    public void SetEnum(System.Type T)
    {
        EnumType = T;
        string[] enumList = System.Enum.GetNames(T);
        dropdown.ClearOptions();
        List<Dropdown.OptionData> dataList = new List<Dropdown.OptionData>();
        for (int i = 0; i < enumList.Length; i++)
        {
            dataList.Add(new Dropdown.OptionData(enumList[i]));
        }
        dropdown.AddOptions(dataList);
    }

    public override object GetValue()
    {
        return System.Enum.Parse(EnumType, dropdown.captionText.text);
    }

    public override void SetValue(object value)
    {
        Label.text = value.ToString();
    }

    public object GetValue_Enum<T>() where T : System.Enum
    {
        return System.Enum.Parse(typeof(T), dropdown.captionText.text);
    }

    public void SetValue_Enum<T>(object value) where T : System.Enum
    {
        Label.text = value.ToString();
    }

    public override void SetLabel(string value)
    {
        Label.text = value;
    }

    public override string GetLabel()
    {
        return Label.text;
    }
}
