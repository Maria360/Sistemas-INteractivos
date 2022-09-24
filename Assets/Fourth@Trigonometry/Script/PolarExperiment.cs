using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarExperiment : MonoBehaviour
{
    [SerializeField] private float angleDegree;
    [SerializeField] private float radius = 1;
    [SerializeField] private float angularvelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angleDegree -= angularvelocity * Time.deltaTime;
        Polar2Cartesian(angleDegree, radius).Draw(Color.red);
       
    }
    //convierte de polar a cartesiano
    MyVector Polar2Cartesian(float angle,float rad) 
    {
        float x = Mathf.Cos(angleDegree * Mathf.Deg2Rad);
        float y = Mathf.Sin(angleDegree * Mathf.Deg2Rad);
        MyVector unitdir = new MyVector(x * radius, y * radius);
        return unitdir;
    }
}
