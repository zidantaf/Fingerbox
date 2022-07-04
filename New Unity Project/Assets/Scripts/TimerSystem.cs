using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerSystem : MonoBehaviour
{
    public float currentTime = 0f;
    public float timer = 25f;

    public Text CountDownText;
    void Start()
    {
        currentTime = timer;
    }
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            print(currentTime);
            CountDownText.text = currentTime.ToString("0") + "s";
        }

        if (currentTime < 3f) { CountDownText.color = Color.red; }

        if (currentTime <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}