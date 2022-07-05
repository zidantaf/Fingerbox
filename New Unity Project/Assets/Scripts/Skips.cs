using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Skips : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


        }
    }
}
