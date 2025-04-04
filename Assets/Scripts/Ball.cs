using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    public GameManager gameManager;

    

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        
    }
    
    private void OnCollisionExit(Collision other)
    {
        var velocity = m_Rigidbody.linearVelocity;

        if (other.gameObject.CompareTag("Right"))
        {
            if(velocity.x < 0)
            {
                velocity.x = -velocity.x;
            }
            else
            {
                velocity.x += 0.5f;
            }

            
        }
        if(other.gameObject.CompareTag("Left"))
        {
            if (velocity.x > 0)
            {
                velocity.x = -velocity.x;
            }
            else
            {
                velocity.x -= 0.5f;
            }
            

        }


        //after a collision we accelerate a bit
        velocity += velocity.normalized * 0.01f;
        
        //check if we are not going totally vertically as this would lead to being stuck, we add a little vertical force
        if (Vector3.Dot(velocity.normalized, Vector3.up) < 0.1f)
        {
            velocity += velocity.y > 0 ? Vector3.up * 0.5f : Vector3.down * 0.5f;
        }

        // Ensure the ball is not stuck moving vertically
        if (Mathf.Abs(velocity.x) < 0.1f)
        {
            velocity.x += velocity.x > 0 ? 0.5f : -0.5f;
        }

        //max velocity
        if (velocity.magnitude > (1.5f + gameManager.level * 0.5f))
        {
            velocity = velocity.normalized * (1.5f + gameManager.level * 0.5f);
        }

        //Make a booster when hitting the special part of the paddle
        if (other.gameObject.CompareTag("Right") || other.gameObject.CompareTag("Left"))
        {
            velocity = (1.5f + gameManager.level * 0.5f) * 2 * velocity.normalized;
        }

        m_Rigidbody.linearVelocity = velocity;


        if (other.gameObject.CompareTag("Paddle") || other.gameObject.CompareTag("Right") || other.gameObject.CompareTag("Left"))
        {
            gameManager.isPaddle = true;
        }
        else
        {
            gameManager.isPaddle = false;

        }

    }
}
