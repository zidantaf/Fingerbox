using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            FindObjectOfType<CameraFollow>(false);
            gameHasEnded = true;
            Debug.Log("Game Over!"); 
            Invoke("Restart", restartDelay);
        }
    }

    

    public void Restart ()
    {

        FindObjectOfType<CameraFollow>();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
