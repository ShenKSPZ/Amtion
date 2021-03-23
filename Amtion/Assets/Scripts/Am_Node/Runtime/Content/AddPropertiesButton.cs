using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Amtion.Node.Runtime
{
    public class AddPropertiesButton : MonoBehaviour
    {
        public void AddProperties()
        {
            transform.GetComponentInParent<RuntimeNode>().AddProperties();
        }
    }
}