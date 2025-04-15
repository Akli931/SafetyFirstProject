using UnityEngine;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; 
    public string message = "Bienvenue parmis nous! Il te faut une formation pour commencer , dirige toi vers ton Bureau et clique sur ton PC pour détecter les anomalies ! Bon courage !";
    private bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            dialogueText.text = message;
            dialogueText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueText.gameObject.SetActive(false);
        }
    }
}