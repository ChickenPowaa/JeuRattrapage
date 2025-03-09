using UnityEngine;

public class GunTake : MonoBehaviour
{
    public GameObject gun; // Le pistolet à activer

    private void OnTriggerEnter(Collider other)
    {
        gun.SetActive(true); // Active le pistolet
        Debug.Log("Gun activé !");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
