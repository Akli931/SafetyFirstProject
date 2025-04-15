using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class LoginUI : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public TMP_Text messageText;

    public void OnRegisterClick()
    {
        string user = usernameField.text;
        string pass = passwordField.text;

        if (DatabaseManager.Instance.Register(user, pass))
        {
            messageText.text = "Compte cr�� avec succ�s ! Connectez vous !";
        }
        else
        {
            messageText.text = "Nom d'utilisateur d�j� pris.";
        }
    }

    public void OnLoginClick()
    {
        string user = usernameField.text;
        string pass = passwordField.text;

        if (DatabaseManager.Instance.Login(user, pass))
        {
            messageText.text = "Connexion r�ussie !";
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            messageText.text = "Identifiants incorrects.";
        }
    }
}
