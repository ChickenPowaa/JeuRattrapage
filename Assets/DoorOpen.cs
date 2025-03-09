using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour
{
    public GameObject Door;
    private Renderer ButtonRenderer;

    public bool doorIsOpening = false;
    // Update is called once per frame
    public Transform joueur; // Référence du joueur (FirstPersonController)
    public float distanceMax = 2f; // Distance max pour interagir


    void Start()
    {
        ButtonRenderer = GetComponent<Renderer>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0)) // 1 = clic droit
        {              
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform && JoueurProche()) // Vérifie la distance
                {    
                    if (!doorIsOpening)
                    {
                        doorIsOpening = true;
                        ButtonRenderer.material.color = Color.green; // Change en vert
                        if (Door != null)
                        {
                            Door.SetActive(false); // Désactive la porte au lieu de la supprimer
                            Debug.Log("Porte ouverte !");
                        }                    
                    }
                }
            }
        }       
    }
    
    bool JoueurProche()
    {
        return Vector3.Distance(transform.position, joueur.position) <= distanceMax;
    }

}
