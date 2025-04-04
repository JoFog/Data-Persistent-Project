using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameManager Manager;

    private AudioSource deathSound;

    private void Start()
    {
        deathSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        deathSound.Play();
        Destroy(other.gameObject);
        Manager.GameOver();
    }
}
