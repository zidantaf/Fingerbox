using UnityEngine;

public class StopMoveTrigger : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public PlayerMovement playermovement;

    public void OnTriggerEnter(Collider other)
    {
        playerRigidbody.constraints = RigidbodyConstraints.FreezePositionX;
        playermovement.enabled = false;
    }

}

