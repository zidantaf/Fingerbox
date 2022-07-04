using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public float scoreDelay = 1f;


    void Update()
    {
        scoreText.text = player.position.z.ToString("0");
    }
}
