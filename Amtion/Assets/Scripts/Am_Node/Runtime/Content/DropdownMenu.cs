using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownMenu : MonoBehaviour
{
    public Dropdown dropdown;

    public void SetEnum<T>() where T : System.Enum
    {
        string[] enumList = System.Enum.GetNames(typeof(T));
        dropdown.ClearOptions();
        List<Dropdown.OptionData> dataList = new List<Dropdown.OptionData>();
        for (int i = 0; i < enumList.Length; i++)
        {
            dataList.Add(new Dropdown.OptionData(enumList[i]));
        }
        dropdown.AddOptions(dataList);
    }

    public object GetEnum<T>() where T : System.Enum
    {
        return System.Enum.Parse(typeof(T), dropdown.captionText.text);
    }
}
