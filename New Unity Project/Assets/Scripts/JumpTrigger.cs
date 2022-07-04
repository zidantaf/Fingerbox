using UnityEngine;

public class JumpTrigger : MonoBehaviour


{
    public Rigidbody theBox;
    public float forcex;
    public float forcez;

    void OnTriggerEnter (Collider other)
    {
        theBox.isKinematic = false;
        theBox.AddForce(forcex, 0, forcez, ForceMode.VelocityChange);
    }

}
