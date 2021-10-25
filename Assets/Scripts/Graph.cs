using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10,100)]
    int resolution = 10;

    Transform [] points;

    public StatisticsManager function;

    void Awake()
    {
        float step = 2f / resolution;
        var scale = Vector3.one * step;

        points = new Transform[resolution*resolution];
        for(int i = 0 ; i < points.Length ; i++)
        {
            Transform point = Instantiate(pointPrefab);
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }

    }

    void Update()
    {
        float time = Time.time;
        float step = 2f / resolution;
        float v = 0.5f*step-1f;
        for(int i = 0, x = 0, z = 0 ; i < points.Length ; i++, x++)
        {
            if(x==resolution)
            {
                x=0;
                z+=1;
                v = (z+0.5f)*step-1f; 
            }
            float u = (x+0.5f)*step-1f;      
            points[i].localPosition = new Vector3(time,0,function.numberOfAirplanesWithVirusCases);
            Debug.Log(points[i].localPosition);
        }
    }
}
