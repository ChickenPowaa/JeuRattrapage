using UnityEngine;

public class SphereInteraction : MonoBehaviour
{
    public GameObject porte; // Assigne la porte depuis l'inspecteur
    private Renderer SphereRenderer;
    private bool isActivated = false;
    public float distanceMax = 2f; // Distance max pour interagir
    public Transform joueur; // Référence du joueur (FirstPersonController)

    void Start()
    {
        SphereRenderer = GetComponent<Renderer>();
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
                    ActiverSphere();
                }
            }
        }
    }

    bool JoueurProche()
    {
        return Vector3.Distance(transform.position, joueur.position) <= distanceMax;
    }


    void ActiverSphere()
    {
        if (!isActivated)
        {
            isActivated = true;
            SphereRenderer.material.color = Color.green; // Change en vert
            OuvrirPorte();
        }
    }

    void OuvrirPorte()
    {
        if (porte != null)
        {
            porte.SetActive(false); // Désactive la porte au lieu de la supprimer
            Debug.Log("Porte ouverte !");
        }
    }
}
