using UnityEngine.Audio;
using UnityEngine;

public class BallSounds : MonoBehaviour
{
    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "ThePlayer")
        {
            GetComponent<AudioSource>().Play();
        }

        if (collisionInfo.collider.tag == "Obstacle")
        {
            GetComponent<AudioSource>().Play();

        }

        if (collisionInfo.collider.tag == "Statics")
        {
            GetComponent<AudioSource>().Play();

        }
    }
}
