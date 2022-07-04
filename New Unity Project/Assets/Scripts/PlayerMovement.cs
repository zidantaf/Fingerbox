using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform tf;
    public float speed = 150;
    public float lompatawal = 10;
    public float geraksamping = 50;
    public float rotasi = 5;
    public Rigidbody jumpscareRb;
    public float jumpscare = 10;
    public MeshRenderer meshRender;

    // Start is called before the first frame update
    public void Start ()
    {
        rb.AddForce(0, lompatawal, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, speed * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            // Geser kanan dan rotasi kanan
            rb.AddForce(geraksamping * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            tf.Rotate(0, rotasi, 0);
        }

        if (Input.GetKey("right"))
        {
            // Geser kanan dan rotasi kanan
            rb.AddForce(geraksamping * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            tf.Rotate(0, rotasi, 0);
        }

        if (Input.GetKey("a"))
        {
            // Geser kiri dan rotasi kiri
            rb.AddForce(-geraksamping * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            tf.Rotate(0, -rotasi, 0);
        }

        if (Input.GetKey("left"))
        {
            // Geser kiri dan rotasi kiri
            rb.AddForce(-geraksamping * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            tf.Rotate(0, -rotasi, 0);
        }

        if (transform.position.y <= 0)
        {
            //Akan diisi Audio
            FindObjectOfType<GameManager>().EndGame();
        }


    }

}
