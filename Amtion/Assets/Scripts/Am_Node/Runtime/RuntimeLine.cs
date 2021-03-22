using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;

[RequireComponent(typeof(LineRenderer))]
public class RuntimeLine : MonoBehaviour
{
    public LineRenderer Renderer;
    public RuntimePort A;
    public RuntimePort B;
    public Transform TA;
    public Transform TAA;
    public Transform TB;
    public Transform TBB;
    public int segmentNum = 50;

    public void Draw(RuntimePort a, RuntimePort b)
    {
        RuntimeGraph.I().Lines.Add(this);
        A = a;
        B = b;
    }

    public void Draw()
    {
        Vector3[] points = Bezier.GetThreePowerBeizerList(TA.position, TAA.position, TBB.position, TB.position, segmentNum);
        Renderer.positionCount = segmentNum;
        Renderer.SetPositions(points);
    }

    private void Update()
    {
        Draw();
    }
}
