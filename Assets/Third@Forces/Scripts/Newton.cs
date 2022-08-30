using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newton : MonoBehaviour
{
    private MyVector position;
    private MyVector acceleration;


    [SerializeField] private MyVector velocity;
    [SerializeField] Newton blackHole;

    public float mass = 1;


    [Header("Other")]
    [Range(0, 1)] [SerializeField] float damping = 1;
    [Range(0, 1)] [SerializeField] float gravity = -9.8f;

    private void Start()
    {
        position = transform.position;
    }
    private void FixedUpdate()
    {
        MyVector r = blackHole.transform.position - transform.position;
        float rMagnitude = r.magnitude;
        MyVector F = r.normalized * (1 / blackHole.mass * mass / rMagnitude * rMagnitude);

        float weightScalar = mass * gravity;
        MyVector weight = new MyVector(0, weightScalar);
        acceleration *= 0f;

        //ApplyForce(weight);
        ApplyForce(F);
        Move();

        //debug
        F.Draw2(position, Color.blue);

    }
    private void Update()
    {
        //Debug vectors
        //position.Draw(Color.red);
        velocity.Draw2(position, Color.cyan);

        //acceleration.Draw2(position, Color.white);
        //Move();
    }
    public void Move()
    {
        //Integrate by Euler method
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;

        if (velocity.magnitude >= 3f)
        {
            velocity.Normalize();
            velocity *= 3;
        }
        //update position
        transform.position = position;

    }
    void ApplyForce(MyVector force)
    {
        acceleration += force * (1f / mass);
    }
}
