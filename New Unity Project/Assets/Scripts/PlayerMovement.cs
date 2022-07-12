using UnityEngine;
using UnityEngine.UI;

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
    public Text velocityText;

    public float lajusamping;
    public float laju;
    public float maxspeeeed;

    // Start is called before the first frame update
    public void Start ()
    {
        rb.AddForce(0, lompatawal, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocityText.text = rb.velocity.magnitude.ToString("0");

        Vector3 clampVel = rb.velocity;
        clampVel.x = Mathf.Clamp(clampVel.x, -7, 7);
        clampVel.z = Mathf.Clamp(clampVel.z, 0, 8);

        rb.velocity = clampVel;

        Vector3 clampRotation = tf.rotation.eulerAngles;
        clampRotation.y = Mathf.Clamp(clampRotation.y, -30, 30);

        rb.AddForce(0, 0, 20 * Time.deltaTime, ForceMode.VelocityChange);

        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rb.AddForce(0, 0, -laju * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            // Geser kanan dan rotasi kanan
            rb.AddForce(lajusamping * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            tf.Rotate(0, rotasi, 0);
            clampRotation.y = Mathf.Clamp(clampRotation.y, -30, 30);
        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            // Geser kiri dan rotasi kiri
            rb.AddForce(-lajusamping * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            tf.Rotate(0, -rotasi, 0);
            clampRotation.y = Mathf.Clamp(clampRotation.y, -30, 30);
        }

        if (transform.position.y <= 0)
        {
            //Akan diisi Audio
            FindObjectOfType<GameManager>().EndGame();
        }

    }

    private float empat = 4.5f;
    public void TeleportFinish()
    {

        transform.position = new Vector3(0, empat, 173);
    }

}
