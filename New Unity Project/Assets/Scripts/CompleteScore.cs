using UnityEngine;
using UnityEngine.UI;

public class CompleteScore : MonoBehaviour
{
    public Transform player;
    public Text scoreText;


    void Update()
    {
        scoreText.text = ("Score : ") + 
            player.position.z.ToString("0");
    }
}
