using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform playercoor;
    public Vector3 jarak;

    public void Update ()
    {
        transform.position = playercoor.position + jarak ; 

    }
}
