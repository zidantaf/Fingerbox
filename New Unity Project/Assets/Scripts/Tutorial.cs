using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public Transform player;
    public GameObject mark1;
    public GameObject mark2;
    public GameObject pengarah0;
    public GameObject pengarah15;
    public GameObject pengarah1;
    public GameObject pengarah2;
    public GameObject pengarah3;
    public GameObject pengarah4;
    public GameObject pengarahMati;
    public GameObject timerCountdown;
    public GameObject pengarahAkhir;
    public GameObject pengarahAkhir2;
    public GameObject completeLevelUi;
    public GameObject BGSong;

    public Rigidbody rb;

    private int openTutorialInt;

    private bool isPengarahAkhir = false;
    private bool isPengarahMati = false;
    private bool isPengarah0 = false;
    private bool isPengarah15 = false;
    private bool isPengarah1 = false;
    private bool isPengarah2 = false;
    private bool isPengarah3 = false;
    private bool isPengarah4 = false;

    private bool isSekali15 = false;
    private bool isSekali2 = false;
    private bool isSekali3 = false;
    private bool isSekali4 = false;
    private bool isSekaliAkhir = false;
    public bool isSekaliAkhir2 = false;

    private float starminim1 = 0f;
    private float starminim2 = 0f;
    private float starminim3 = 0f;

    public GameObject OneStar;
    public GameObject TwoStar;
    public GameObject ThreeStar;

    public float boostspeed = 50;

    public float timers;
    public Text CountDownText;

    public float outZone = 8f;

    public PlayerMovement pmovement;

    private void Start()
    {
        openTutorialInt = PlayerPrefs.GetInt("OpenTutorial");
        pmovement.enabled = false;

        if (openTutorialInt == 0)
        {
            rb.isKinematic = true;
            pengarah0.SetActive(true);
            isPengarah0 = true;
        }
            
    }
    void Update()
    {
        if (openTutorialInt == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isPengarah0 == true)
                {

                    pengarah0.SetActive(false);
                    pengarah1.SetActive(true);
                    isPengarah0 = false;
                    StartCoroutine(IsPengarah1());

                }

                if (isPengarah1 == true)
                {
                    pmovement.enabled = true;
                    isPengarah1 = false;
                    rb.isKinematic = false;
                    pengarah1.SetActive(false);
                    StopCoroutine(IsPengarah1());
                    rb.AddForce(0, 0, 200f);
                }

                if (isPengarah2 == true)
                {
                    isSekali2 = true;
                    pmovement.enabled = true;
                    isPengarah2 = false;
                    pengarah2.SetActive(false);
                    rb.isKinematic = false;
                    rb.AddForce(0, 0, 200f);
                }

                if (isPengarah15 == true)
                {
                    isSekali15 = true;
                    pmovement.enabled = true;
                    pengarah15.SetActive(false);
                    rb.isKinematic = false;
                    isPengarah15 = false;
                    rb.AddForce(0, 0, 200f);
                }

                if (isPengarah3 == true)
                {
                    isPengarah3 = false;
                    isSekali3 = true;
                    pmovement.enabled = true;
                    pengarah3.SetActive(false);
                    rb.isKinematic = false;
                    rb.AddForce(0, 0, 200f);
                }

                if (isPengarah4 == true)
                {
                    isPengarah4 = false;
                    isSekali4 = true;
                    pmovement.enabled = true;
                    pengarah4.SetActive(false);
                    rb.isKinematic = false;
                    rb.AddForce(0, 0, 200f);
                }

                if (isPengarahMati == true)
                {
                    
                    isPengarahMati = false;
                    rb.AddForce(0, 0, 200f);
                }

                if (isPengarahAkhir == true && isSekaliAkhir == false)
                {
                    pengarahAkhir.SetActive(false);
                    isSekaliAkhir = true;
                    pmovement.enabled = true;
                    rb.isKinematic = false;
                    rb.AddForce(0, 0, 250f);

                    InvokeRepeating("StartTimer", 1, 1);
                }
            }

            // Diatas adalah SPACE ----------------------------

            if (player.position.x >= outZone)
            {

                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                pengarahMati.SetActive(true);
                pengarahMati.GetComponent<Animator>().Play("PengarahMati");
                
                rb.AddForce(0, 50f, 200f);

                if (isPengarahAkhir == true)
                {
                    transform.position = new Vector3(0, 2f, 132f);
                    timers = 20;

                    timerCountdown.SetActive(false);

                    timerCountdown.SetActive(true);

                }
                else
                {
                    float y = 2.14f;
                    transform.position = new Vector3(0, y, 0);
                }
            }
        
            if (player.position.x <= -outZone)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                pengarahMati.SetActive(true);
                pengarahMati.GetComponent<Animator>().Play("PengarahMati");

                rb.AddForce(0, 50f, 200f);

                if (isPengarahAkhir == true)
                {
                    transform.position = new Vector3(0, 2f, 132f);
                    timers = 20;

                    timerCountdown.SetActive(false);

                    timerCountdown.SetActive(true);

                }
                else
                {
                    float y = 2.14f;
                    transform.position = new Vector3(0, y, 0);
                }
            }
            

            if (player.position.z >= 17f)
            {
                mark1.SetActive(false);
            }

            if (player.position.z >= 211f)
            {
                mark2.SetActive(false);
            }

            if (timers <= 5)
            {
                CountDownText.color = Color.red;
            }
            else
            {
                CountDownText.color = Color.white;
            }

            if (timers <= 0)
            {
                transform.position = new Vector3(0, 2f, 132f);
                timers = 20;

                Vector3 zeroRot = new Vector3(0, 0, 0);

                transform.Rotate(zeroRot);
                rb.AddForce(0, 0, 100f);
                pmovement.enabled = true;
            }
        }
    }

    public void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.name == "Pengarah15")
        {
            if (openTutorialInt == 0)
            {
                if (isPengarah15 == false && isSekali15 == false)
                {
                    pmovement.enabled = false;
                    isSekali15 = true;
                    isPengarah15 = true;
                    rb.isKinematic = true;
                    pengarah15.SetActive(true);
                }
            }
        }

        if (collisionInfo.gameObject.name == "Pengarah2")
        {
            if (openTutorialInt == 0)
            {
                if (isPengarah2 == false && isSekali2 == false)
                {
                    pmovement.enabled = false;
                    isSekali2 = true;
                    isPengarah2 = true;
                    rb.isKinematic = true;
                    pengarah2.SetActive(true);
                }
            }
        }

        if (collisionInfo.gameObject.name == "Pengarah3")
        {
            if (openTutorialInt == 0)
            {
                if (isPengarah3 == false && isSekali3 == false)
                {
                    pmovement.enabled = false;
                    isSekali3 = true;
                    isPengarah3 = true;
                    rb.isKinematic = true;
                    pengarah3.SetActive(true);
                }
            }
        }

        if (collisionInfo.gameObject.name == "Pengarah4")
        {
            if (openTutorialInt == 0)
            {
                if (isPengarah4 == false && isSekali4 == false)
                {
                    pmovement.enabled = false;
                    isSekali4 = true;
                    isPengarah4 = true;
                    rb.isKinematic = true;
                    pengarah4.SetActive(true);
                }
            }
        }

        if (collisionInfo.gameObject.name == "PengarahAkhir")
        {
            if (openTutorialInt == 0)
            {
                if (isPengarahAkhir == false)
                {
                    pmovement.enabled = false;
                    isPengarahAkhir = true;
                    rb.isKinematic = true;
                    pengarahAkhir.SetActive(true);
                    timerCountdown.SetActive(true);

                    mark2.SetActive(true);
                }
            }
        } 
    }

    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Statics")
        {
            GetComponent<AudioSource>().Play();
        }

        if (collisionInfo.gameObject.name == "EndLine")
        {
            pmovement.enabled = false;
            CancelInvoke();

            if (timers >= starminim1)
            {
                StartCoroutine(OneS());
            }
            if (timers >= starminim2)
            {
                print("2 Star Earned.");
                StartCoroutine(TwoS());
            }
            if (timers >= starminim3)
            {
                print("3 Star Earned.");
                StartCoroutine(ThreeS());
            }

            StartCoroutine("FreezeP");

            LevelComplete();
        }

        if (collisionInfo.collider.name == "Boost")
        {
            rb.AddForce(0, 0, boostspeed, ForceMode.VelocityChange);

        }

    }

    public void StartTimer()
    {
        timers -= 1;
        CountDownText.text = timers.ToString("0") + "s";
    }

    public void FailedTutorial()
    {
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator IsPengarah1()
    {
        float sekian = 0.5f;
        yield return new WaitForSeconds(sekian);
        isPengarah1 = true;
    }

    public void LevelComplete()
    {
        completeLevelUi.SetActive(true);
        BGSong.SetActive(false);
    }
    
    private float waiting2 = 1.5f;

    private float star1 = 2.0f;
    private float star2 = 2.25f;
    private float star3 = 2.5f;
    IEnumerator OneS()
    {
        yield return new WaitForSeconds(star1);
        OneStar.SetActive(true);
    }

    IEnumerator TwoS()
    {
        yield return new WaitForSeconds(star2);
        TwoStar.SetActive(true);
    }

    IEnumerator ThreeS()
    {
        yield return new WaitForSeconds(star3);
        ThreeStar.SetActive(true);
    }

    IEnumerator FreezeP()
    {
        yield return new WaitForSeconds(waiting2);

        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
