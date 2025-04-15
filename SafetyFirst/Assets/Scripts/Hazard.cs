using UnityEngine;

public class Hazard : MonoBehaviour
{
    private bool isFound = false;

    void OnTriggerEnter(Collider other)
    {
        if (!isFound && other.CompareTag("Player"))
        {
            isFound = true;
            Debug.Log("Danger détecté : " + gameObject.name);
            GetComponent<Renderer>().material.color = Color.green; // feedback visuel
            HazardManager.Instance.RegisterHazard();
        }
    }
}
