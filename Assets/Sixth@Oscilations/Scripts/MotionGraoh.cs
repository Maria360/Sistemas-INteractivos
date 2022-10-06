using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionGraoh : MonoBehaviour
{
    [SerializeField] private GameObject m_pointPrefab;
    [SerializeField] int m_totalSamplePoints = 20;
    [SerializeField] float m_separation = 0.6f;
    [SerializeField] float m_amplitude = 0.5f;

    private List<GameObject> newPoints = new List<GameObject>();

    private void Start()
    {
        for(int i=0; i < m_totalSamplePoints; i++)
        {
            var newPoint = Instantiate(m_pointPrefab, transform);
            newPoints.Add(newPoint);
            
        }
    }
    private void Update()
    {
        for(int i =0; i<m_totalSamplePoints; i++)
        {
            var newPoint = newPoints[i];
            float x = i * m_separation;
            float y = m_amplitude * Mathf.Sin(i + Time.time);
            newPoint.transform.localPosition = new Vector3(x, y);
        }
    }
}
