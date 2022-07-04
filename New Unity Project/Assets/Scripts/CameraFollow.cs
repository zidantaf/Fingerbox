using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playercoor;
    public Vector3 jarak;

    void Update ()
    {
        transform.position = playercoor.position + jarak ; 
    }

    

}
