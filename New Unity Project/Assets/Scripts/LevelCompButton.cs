using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelCompButton : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
