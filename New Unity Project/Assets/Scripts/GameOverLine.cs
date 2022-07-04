using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverLine : MonoBehaviour
{
    public Rigidbody rb;
    public float veloStop = 3;
    public float inerStop = 1;
    public StopMoveTrigger stopMove;
    public GameObject player;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            if (player.transform.position.y < 0)
            {
                //Akan diisi Audio : Mati jatuh
                FindObjectOfType<GameManager>().EndGame();
            }

        }
    }

   



}

