using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAttraction : MonoBehaviour
{
    private MyVector position;
    private MyVector acceleration;

    [SerializeField] float mass = 1;
    [SerializeField] float BHmass = 1;
    [SerializeField]private MyVector velocity;


    [SerializeField] Transform blackHole;


    [Header("Other")]
    [Range(0, 1)] [SerializeField] float damping = 1;
    [Range(0, 1)] [SerializeField] float gravity = -9.8f;

    private void Start()
    {
        position = transform.position;
    }
    private void FixedUpdate()
    {
        MyVector r = blackHole.position - transform.position;
        float rMagnitude = r.magnitude;
        MyVector F = r.normalized * (1 / BHmass * mass / rMagnitude * rMagnitude);

        float weightScalar = mass * gravity;
        MyVector weight = new MyVector(0, weightScalar);
        acceleration *= 0f;

        //ApplyForce(weight);
        ApplyForce(F);
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
        //if (Mathf.Abs(position.x) >= 5)
        //{
        //    position.x = Mathf.Sign(position.x) * 5;
        //    velocity.x *= -1;
        //    velocity *= damping;
        //}
        //if (Mathf.Abs(position.y) >= 5)
        //{
        //    position.y = Mathf.Sign(position.y) * 5;
        //    velocity.y *= -1;
        //    velocity *= damping;
        //}

        //update position
        transform.position = position;

    }
    void ApplyForce(MyVector force)
    {
        acceleration += force * (1f / mass);
    }
}
