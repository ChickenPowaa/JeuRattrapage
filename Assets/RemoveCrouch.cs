using UnityEngine;

public class RemoveCrouch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        Crouch crouchScript = other.GetComponent<Crouch>();
        if (crouchScript != null)
        {
            Destroy(crouchScript);
            Debug.Log("Sprint désactivé dans cette zone !");
        }
    }

}
