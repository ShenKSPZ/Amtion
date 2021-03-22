using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RuntimeLine : MonoBehaviour
{
    public LineRenderer Renderer;
    public RuntimePort A;
    public RuntimePort B;

    public void Draw(RuntimePort a, RuntimePort b)
    {
        RuntimeGraph.I().Lines.Add(this);
        A = a;
        B = b;
    }
}
