using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Triangle : MonoBehaviour
{
    public Vector2 point1;
    public Vector2 point2;
    public Vector2 point3;
    private void Awake()
    {
        
    }

    private void Start()
    {
        point1 = new Vector2(Random.Range(0, 100), Random.Range(0, 100));
        point2 = new Vector2(Random.Range(0, 100), Random.Range(0, 100));
        point3 = new Vector2(Random.Range(0, 100), Random.Range(0, 100));
        Debug.Log("point1:"+point1+"point2:"+ point2+"point3:"+ point3);
        Vector2 randPoint1 = GetPos(point1, point2);
        Vector2 randPoint2 = GetPos(point1, point3);

        Vector2 finalPoint = GetPos(randPoint1, randPoint2);
        Debug.Log(finalPoint);
    }

    public Vector2 GetPos(Vector2 p1,Vector2 p2)
    {
        Vector2 pos = Vector2.zero;
        float dis = Vector2.Distance(p1, p2);
        Vector2 vector2 = (p2 - p1).normalized;
        float rand = Random.Range(0, dis);
        pos = vector2 * rand;
        pos += p1;
        return pos;
    }
}
