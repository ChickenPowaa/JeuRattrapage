using UnityEngine;

public class RemoveJump : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        Jump jumpScript = other.GetComponent<Jump>();
        if (jumpScript != null)
        {
            Destroy(jumpScript);
            Debug.Log("Jump désactivé dans cette zone !");
        }
    }

}
