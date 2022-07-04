using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement pmovement;
    public Rigidbody rb;
    public float boostspeed = 50;
    public Rigidbody rbjump;
    public GameObject dug;
    public GameObject myCam;

    public GameObject completeLevelUi;
    public GameObject BGSong;
    bool isFinish = false;

    public int currentTime;
    private int actualScore;
    public int timer;
    public Text CountDownText;
    public Text HighscoreText;

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
            isFinish = true;
            LevelComplete();
            StopCoroutine(WaitBeforeShow());
            StopTimer();
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
        StartTimer();
        InvokeRepeating("IncrinentTime", 0, 1);

        HighscoreText.text = "HIGHSCORE : " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    private void Update()
    {
        if (currentTime <= 5) 
        {
            CountDownText.color = Color.red; 
        }

        if (currentTime <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void StartTimer()
    {

    }

    public void StopTimer()
    {
        actualScore = timer + currentTime;

        CancelInvoke();

        if (PlayerPrefs.GetInt("Highscore") < actualScore)
        {
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

}


