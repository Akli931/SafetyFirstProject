using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondScene : MonoBehaviour
{
    public bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange)
        {
            SceneManager.LoadScene("Scene2");
        }
    }
}
