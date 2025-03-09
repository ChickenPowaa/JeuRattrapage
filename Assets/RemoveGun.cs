using UnityEngine;

public class RemoveGun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        GameObject gun = GameObject.FindWithTag("Gun");
        if (gun != null)
        {
            Destroy(gun); // Supprime la porte définitivement
            // door.SetActive(false); // Si tu veux juste la désactiver
            Debug.Log("Gun supprimée !");
        }
    }


}
