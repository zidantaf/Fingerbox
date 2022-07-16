using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform tf;
    public Text velocityText;

    public float staticSpeed = 10f;
    public float maxStaticSpeed = 25f;
    public float maxXSpeed = 25f;
    public float xSpeed = .1f;

    public float lompatawal = 10;
    public float yRotation;
    public float rotationSpeed = 5f;


    [SerializeField] private AnimationCurve curveX;

    // Start is called before the first frame update
    public void Start ()
    {
        rb.AddForce(0, lompatawal, 0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float xDirection = Input.GetAxis("Horizontal");
        Vector3 moveX = new Vector3(xDirection, 0, 0);

        rb.AddForce(moveX * xSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        rb.AddForce(0, 0, staticSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        Vector3 veloClamp = rb.velocity;
        veloClamp.x = Mathf.Clamp(veloClamp.x, -maxXSpeed, maxXSpeed);
        veloClamp.z = Mathf.Clamp(veloClamp.z, -maxStaticSpeed, maxStaticSpeed);

        rb.velocity = veloClamp;

        if (transform.position.y <= -2.5f)
        {
            //Akan diisi Audio
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void Update()
    {
        yRotation = transform.eulerAngles.y;

        if (yRotation <= 30f || yRotation >= 330f)
        {
            float xDirection = Input.GetAxis("Horizontal");

            if (Input.GetAxis("Horizontal") > 0)
            {
                yRotation += rotationSpeed * xDirection;
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                yRotation += rotationSpeed * xDirection;
            }
        }

        if (yRotation >= 30f && yRotation < 180f)
        {
            yRotation = 29.9f;
        }

        if (yRotation <= 330f && yRotation > 180f)
        {
            yRotation = 330.1f;
        }

        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }


    private float empat = 4.5f;
    public void TeleportFinish()
    {

        transform.position = new Vector3(0, empat, 173);
    }

}
