using UnityEngine;

public class JumpTrigger2 : MonoBehaviour

{
    public Rigidbody rbSlur;
    public float gerakKaget = 10f;
    public void OnTriggerEnter(Collider other)
    {
        rbSlur.AddForce(gerakKaget, 0, 0, ForceMode.VelocityChange);
    }

}