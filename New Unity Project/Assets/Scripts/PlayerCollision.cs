using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerCollision : MonoBehaviour
{
    public Transform transfroms;

    public PlayerMovement pmovement;
    public Rigidbody rb;
    public float boostspeed = 50;
    public Rigidbody rbjump;
    public GameObject dug;
    public GameObject myCam;
    public GameObject Newest;

    public GameObject completeLevelUi;
    public GameObject BGSong;
    bool isFinish = false;

    public int currentTime;
    private int actualScore;
    public int timer;
    public Text CountDownText;
    public Text ScoreText;
    public Text HighscoreText;

    public GameObject OneStar;
    public GameObject TwoStar;
    public GameObject ThreeStar;

    public float starminim1 = 21.0f;
    public float starminim2 = 23.0f;
    public float starminim3 = 25.0f;

    public void OnCollisionEnter(Collision collisionInfo)
    {
        
        if (collisionInfo.collider.tag == "Obstacle")
        {
            pmovement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            dug.SetActive(true);

            GetComponent<AudioSource>().Play();
        }

        if (collisionInfo.collider.name == "EndLine")
        {
            StartCoroutine("FreezeP");
            
            isFinish = true;
            LevelComplete();
            StopCoroutine(WaitBeforeShow());
            StopTimer();

            if (actualScore >= starminim1)
            {
                StartCoroutine(OneS());
            }
            if (actualScore >= starminim2)
            {
                print("2 Star Earned.");
                StartCoroutine(TwoS());

                if (actualScore >= starminim3)
                {
                    print ("Full Stars!");
                }
                
            }
            if (actualScore >= starminim3)
            {
                print("3 Star Earned.");
                StartCoroutine(ThreeS());
            }
        }

        if (collisionInfo.collider.name == "FinishLine")
        {
            pmovement.rotasi = 0;
            pmovement.geraksamping = 0;
            GetComponent<AudioSource>().Play();
        }

        if (collisionInfo.collider.name == "Boost")
        {
         rb.AddForce(0, 0, boostspeed, ForceMode.VelocityChange);
         
        }

        if (collisionInfo.collider.name == "Jumpscare Collider")
        {
                rbjump.isKinematic = false;
        }

        if (collisionInfo.collider.tag == "Bouncy")
        {
                //Diisi Audio "Bouncy"
        }

        if (collisionInfo.collider.tag == "Statics")
        {
            GetComponent<AudioSource>().Play();
        }
    }

    void Start()
    {
        currentTime = timer + 1;
        InvokeRepeating("IncrinentTime", 0, 1);

        HighscoreText.text = "HIGHSCORE : " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    private void Update()
    {
        if (isFinish == false)
        {
            if (transfroms.position.z >= 211)
            {
                Restart();
            }

            if (transfroms.position.x >= 15)
            {
                Restart();
            }

            if (transfroms.position.x <= -15)
            {
                Restart();
            }
        }

        if (currentTime <= 5) 
        {
            CountDownText.color = Color.red; 
        }

        if (currentTime <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    

    public void StopTimer()
    {
        actualScore = timer + currentTime;
        ScoreText.text = "SCORE : " + actualScore;

        CancelInvoke();

        if (PlayerPrefs.GetInt("Highscore") < actualScore)
        {
            StartCoroutine("NewHighscore");
            SetHighScore();
        }
    }

    public void SetHighScore()
    {
        PlayerPrefs.SetInt("Highscore", actualScore);
        HighscoreText.text = "HIGHSCORE : " + actualScore;
    }

    public void DeleteHighscore()
    {
        PlayerPrefs.DeleteKey("Highscore");
        HighscoreText.text = "HIGHSCORE : " + 0;

    }

    void IncrinentTime()
    {
        currentTime -= 1;
        CountDownText.text = currentTime.ToString() + "s";
    }

    public void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "FinishLine")
        {
            StartCoroutine(WaitBeforeShow());

        }
    }

    
    public void LevelComplete()
    {
        completeLevelUi.SetActive(true);
        BGSong.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator WaitBeforeShow()
    {
        yield return new WaitForSeconds(3);
        if (isFinish == false)
        {
            Restart();
        }
    }

    private float waiting = 2.1f;
    private float waiting2 = 1f;

    private float star1 = 2.0f;
    private float star2 = 2.25f;
    private float star3 = 2.5f;

    IEnumerator NewHighscore()
    {
        yield return new WaitForSeconds(waiting);
        Newest.SetActive(true);
    }

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
    }
}


