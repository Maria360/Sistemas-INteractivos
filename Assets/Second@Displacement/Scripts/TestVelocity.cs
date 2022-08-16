using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVelocity : MonoBehaviour
{
    private MyVector position;
    private MyVector displacement;
    private MyVector velocity; //integral de la aceleracion
    [SerializeField] private MyVector acceleration;
    private int currentIndex = 0;   
    MyVector[] accelerations =
    {
        new MyVector(0,-9.8f),
        new MyVector(9.8f,0f),
        new MyVector(0,9.8f),
        new MyVector(-9.8f,0f),
    };
    private void Start()
    {
        position = transform.position; //new MyVector(transform.position.x, transform.position.y);
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        //Debug vectors
        position.Draw(Color.red);
        displacement.Draw2(position, Color.green);
        velocity.Draw2(position, Color.cyan);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity *= 0;
            acceleration = accelerations[(++currentIndex) % accelerations.Length];
        }
        Move();
    }
    public void Move()
    {
        //calculate displacement and new position
        //displacement = velocity * Time.deltaTime;
        //Integrate by Euler method
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
        //check bounds
        if (Mathf.Abs(position.x) >= 5 )
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x *= -1;
        }
        if (Mathf.Abs(position.y) >= 5 )
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y *= -1;
        }
        //update position
        transform.position = position;

    }
}
