using UnityEngine;
using UnityEngine.SceneManagement;

public class EmailManager : MonoBehaviour
{
    public GameObject[] emails;
    public int spamIndex = 2;  

    public void OnEmailClicked(int index)
    {
        if (index == spamIndex)
        {
            Debug.Log("Spam détecté !");
            SceneManager.LoadScene("Scene3");
        }
        else
        {
            Debug.Log("Faux ! Ce n'est pas un spam.");
        }
    }
}
