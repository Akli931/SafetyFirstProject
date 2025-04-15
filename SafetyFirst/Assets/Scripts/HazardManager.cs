using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardManager : MonoBehaviour
{
    public static HazardManager Instance;
    public int totalHazards = 3;
    private int hazardsFound = 0;

    void Awake()
    {
        Instance = this;
    }

    public void RegisterHazard()
    {
        hazardsFound++;
        if (hazardsFound >= totalHazards)
        {
            Debug.Log("Tous les dangers trouvés !");
            SceneManager.LoadScene("Scene4"); 
        }
    }
}
