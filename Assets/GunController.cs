using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Gun Settings")]
    public float fireRate = 0.1f;
    public Image muzzleFlashImage;
    public Sprite[] flashes;
    bool _canShoot;
    public Camera fpsCamera;
    void Start()
    {
        _canShoot = true;
        
    }

    // Update is called once per frame
    void Update()
    {
    if(Input.GetMouseButton(0))
        {
            _canShoot= false;
            StartCoroutine(ShootGun());

        }
    }

    IEnumerator ShootGun(){
        StartCoroutine(MuzzleFlash());
        RayCastForEnemy();
        yield return new WaitForSeconds(fireRate);
        _canShoot = true;
    }

    IEnumerator MuzzleFlash(){
        muzzleFlashImage.sprite = flashes[Random.Range(0, flashes.Length)];
        muzzleFlashImage.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        muzzleFlashImage.sprite = null;
        muzzleFlashImage.color = new Color(0,0,0,0);    }

   void RayCastForEnemy()
    {
        RaycastHit Hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out Hit))
        {
            if (Hit.transform.CompareTag("Cible")) // Vérifie si c'est une cible
            {
                Debug.Log(Hit.transform.name);
                Renderer targetRenderer = Hit.transform.GetComponent<Renderer>();
                
                if (targetRenderer != null)
                {
                    // Changer la couleur du matériau en vert
                    targetRenderer.material.color = Color.green;
                    GameObject door = GameObject.FindWithTag("Porte");
                    if (door != null)
                    {
                        Destroy(door); // Supprime la porte définitivement
                        // door.SetActive(false); // Si tu veux juste la désactiver
                        Debug.Log("Porte supprimée !");
                    }
                }
            }
        }

    }
}