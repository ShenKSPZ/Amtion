using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class TestTwo : MonoBehaviour
{
    public Child type;

    // Start is called before the first frame update
    void Start()
    {
        System.Type t = type.GetType();
        //print("FullName: " + t.Name);
        FieldInfo[] info = t.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        for (int i = 0; i < info.Length; i++)
        {
            //print("PropName: " + info[i].Name);
            //print("Type: " + info[i].FieldType);
            //print("Value: " + info[i].GetValue(type));
            object[] obj = info[i].GetCustomAttributes(false);

            TextAreaAttribute att = (TextAreaAttribute)info[i].GetCustomAttribute(typeof(TextAreaAttribute), false);

            if(att != null)
            {
                //print(att.minLines);
                //print(att.maxLines);
            }

            for (int a = 0; a < obj.Length; a++)
            {
                //print("Attri: " + obj[a]);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
