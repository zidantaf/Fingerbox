using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerCollision : MonoBehaviour
{
    public Transform transfroms;
    public GameObject finishcin;
    public PlayerMovement pmovement;
    public Rigidbody rb;
    public GameObject dug;
    public GameObject myCam;

    public bool isFinish = false;

    public int currentTime;
    private int actualScore;
    public int timer;
    public Text CountDownText;

    public GameObject TimerUI;
    public GameObject VelocityUI;
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

            rb.constraints = RigidbodyConstraints.FreezeRotationX;
            pmovement.enabled = false;
            isFinish = true;
            StopCoroutine(WaitBeforeShow());
            StopTimer();

            TimerUI.GetComponent<Animator>().Play("TimerClosed");
            VelocityUI.GetComponent<Animator>().Play("TimerClosed");

            finishcin.GetComponent<Animator>().Play("UICinematic");

            StartCoroutine(VictoryScene());
        }

        if (collisionInfo.collider.name == "FinishLine")
        {

            GetComponent<AudioSource>().Play();
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
    }

    private void Update()
    {
        if (isFinish == false)
        {
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
    }

    public void DeleteHighscore()
    {
        PlayerPrefs.DeleteKey("Highscore");

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

    IEnumerator VictoryScene()
    {
        yield return new WaitForSeconds(6);

        SceneManager.LoadScene("Finish 1");
    }

    IEnumerator FreezeP()
    {
        yield return new WaitForSeconds(1);

        rb.constraints = RigidbodyConstraints.FreezePosition;
    }
}


