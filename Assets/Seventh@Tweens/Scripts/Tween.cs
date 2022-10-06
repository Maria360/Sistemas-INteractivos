using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{
    
    [SerializeField] Transform target;
    [SerializeField] float time;
    [SerializeField, Range(0, 1)] float tParameter = 0;
    [SerializeField] Color initialColor;
    [SerializeField] Color targetColor;
    [SerializeField] private AnimationCurve curve;
    float currentTime;
    Vector3 initialPosition;
    Vector3 targetPosition;
    SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        //initialPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        tParameter = currentTime / time; //Normalize tParameter
        transform.position = Vector3.LerpUnclamped(initialPosition, targetPosition, curve.Evaluate(tParameter));
        spriteRenderer.color = Color.LerpUnclamped(initialColor, targetColor, curve.Evaluate(tParameter));
        currentTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTween();
        }
    }
    private void StartTween()
    {
        tParameter = 0;
        currentTime = 0;
        initialPosition = transform.position;
        targetPosition = target.position;
    }
    private float EaseInElastic(float x)
    {
        float c5 = (2f * Mathf.PI) / 4.5f;
        return x ==0f
          ? 0f
          : x == 1f
          ? 1f
          : x < 0.5
          ? -(Mathf.Pow(2f, 20f * x - 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f
          : (Mathf.Pow(2f, -20f * x + 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f + 1f;
    }
}
