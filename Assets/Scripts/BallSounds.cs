using UnityEngine;

public class BallSounds : MonoBehaviour
{
    private AudioSource[] ballSound = new AudioSource[2];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballSound = GetComponents<AudioSource>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Right":
                ballSound[1].Play();
                break;
            case "Left":
                ballSound[1].Play();
                break;
            case "Paddle":
                ballSound[0].Play();
                break;
            

            default:
                break;
        }

       
    }


}
