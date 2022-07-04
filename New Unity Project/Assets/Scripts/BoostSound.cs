using UnityEngine.Audio;
using UnityEngine;

public class BoostSound : MonoBehaviour
{
    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "ThePlayer")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
