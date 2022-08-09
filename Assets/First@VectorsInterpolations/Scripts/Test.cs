using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] MyVector firstVector = new MyVector();
    [SerializeField] MyVector secondVector = new MyVector();
    [SerializeField] float n;
    [SerializeField] [Range(0,1)] float t;
    MyVector addResult;
    MyVector subResult;
    MyVector multResult;
    float pmediox, pmedioy;
    MyVector vectorMedio;
    void Start()
    {
        
    }

    void Update()
    {
        firstVector.Draw(Color.cyan);
        secondVector.Draw(Color.green);

        //addResult = firstVector + secondVector;
        subResult = (firstVector - secondVector)*-1;
        //multResult = firstVector * n;

        subResult.Draw2(firstVector, Color.red);
        //addResult.Draw(Color.white);
        //subResult.Draw(Color.red);
        //multResult.Draw(Color.blue);

        pmediox = (firstVector.x + secondVector.x) / 2 ;
        pmedioy = (firstVector.y + secondVector.y) / 2;

        vectorMedio = firstVector.Lerp(secondVector, t);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(vectorMedio, 0.05f);
    }


}
