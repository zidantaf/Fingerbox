using UnityEngine.UI;
using UnityEngine;

public class SpeedTest : MonoBehaviour
{
    public Text thisText;
    public Rigidbody rb;

    void Update()
    {
        float velocity = rb.velocity.magnitude;
        thisText.text = velocity.ToString("0");
        
    }
}
