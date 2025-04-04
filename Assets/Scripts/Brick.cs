using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public UnityEvent<int> onDestroyed;
    private AudioSource brickSound;
    
    public int PointValue;

    void Start()
    {
        var renderer = GetComponentInChildren<Renderer>();
        brickSound = GetComponent<AudioSource>();

        MaterialPropertyBlock block = new();
        switch (PointValue)
        {
            case 1 :
                block.SetColor("_BaseColor", Color.green);
                break;
            case 2:
                block.SetColor("_BaseColor", Color.yellow);
                break;
            case 5:
                block.SetColor("_BaseColor", Color.blue);
                break;
            default:
                block.SetColor("_BaseColor", Color.red);
                break;
        }
        renderer.SetPropertyBlock(block);
    }

    private void OnCollisionEnter(Collision other)
    {
        brickSound.Play();
        DestroyBrick();
    }

    void DestroyBrick()
    {
        onDestroyed.Invoke(PointValue);

        //slight delay to be sure the ball have time to bounce
        Destroy(gameObject, 0.2f);
    }
}
