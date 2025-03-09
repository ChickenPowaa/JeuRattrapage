using UnityEngine;

public class Teleport2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Player;
    public GameObject TeleportTo;
    public GameObject StartTeleporter;
 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Teleporter 2"))
        {
            Player.transform.position = TeleportTo.transform.position;
        }
 

    }
}
