using UnityEngine;

public class FinDuJeu : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si c'est le joueur qui entre
        {
            Debug.Log("Le joueur a atteint la fin. Fermeture du jeu...");
            Application.Quit(); // Ferme le jeu

            // Si on teste dans l'éditeur Unity, on doit aussi arrêter le mode Play :
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}