using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPhysics : MonoBehaviour
{
    private MyVector position;
    private MyVector velocity; 
    private MyVector acceleration;

    [SerializeField] float mass = 1;
    [SerializeField] MyVector wind;
    [Range(0, 1)] [SerializeField] float frictionCoefficient;

    [Header("Other")]
    [SerializeField] bool useFluidFriction = false;
    [Range(0, 1)] [SerializeField] float damping = 1;
    [Range(0, 1)] [SerializeField] float gravity =-9.8f;

    private void Start()
    {
        position = transform.position;
    }
    private void FixedUpdate()
    {
        float weightScalar = mass * gravity;
        MyVector weight = new MyVector(0, weightScalar) ;
        MyVector friction = velocity.normalized * frictionCoefficient * -weightScalar * -1;
        acceleration *= 0f;

        ApplyForce(wind);
        ApplyForce(weight);
        ApplyForce(friction);
        if (useFluidFriction && position.y <= 0f)
        {
            float velocityMagnitude = velocity.magnitude;
            float frontalArea = transform.localScale.x;
            MyVector fluidFriction = velocity.normalized * frontalArea * velocityMagnitude * velocityMagnitude * -0.5f;
            ApplyForce(fluidFriction);
            fluidFriction.Draw2(position, Color.magenta);
        }

        friction.Draw2(position,Color.black);
        Move();
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

        //check bounds
        if (Mathf.Abs(position.x) >= 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x *= -1;
            velocity *= damping;
        }
        if (Mathf.Abs(position.y) >= 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y *= -1;
            velocity *= damping;
        }

        //update position
        transform.position = position;

    }
    void ApplyForce(MyVector force)
    {
        acceleration += force * (1f / mass);
    }
}
