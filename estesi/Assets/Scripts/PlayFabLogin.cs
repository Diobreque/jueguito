using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayFabLogin : MonoBehaviour
{   
    // Definimos variables de objeto para InputField
    public InputField inp_email;
    public InputField inp_password;

    public GameObject go_panel_login;
    public GameObject go_panel_error;


    //variables privadas para recuperar credenciales de acceso desde playerprefs

    private string player_email;

    private string player_password;

    public void Start()
    {
        if(PlayerPrefs.HasKey("PLAYER_EMAIL")){
            player_email = PlayerPrefs.GetString("PLAYER_EMAIL");
            player_password = PlayerPrefs.GetString("PLAYER_PASSWORD");

            var request = new LoginWithEmailAddressRequest { Email = player_email, Password = player_password }; //confifuracion request(solicitud)
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure); //ejecutamos request(solicitud)
        }
    }


    public void LoginEmail()
    {
        // variables de tipo string para almacenar email y clave
        string user_email = inp_email.text;
        string user_password = inp_password.text;
        var request = new LoginWithEmailAddressRequest { Email = user_email, Password = user_password }; //confifuracion request(solicitud)
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure); //ejecutamos request(solicitud)

    }
    private void OnLoginSuccess(LoginResult result)
    {
        // Debug.Log("****** Logeao'! ******");
        if(inp_email.text !=""){
            PlayerPrefs.SetString("PLAYER_EMAIL", inp_email.text);
            PlayerPrefs.SetString("PLAYER_PASSWORD", inp_password.text);
        }
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void VolverLogin()
    {
        go_panel_login.SetActive(true);
        go_panel_error.SetActive(false);
    }

    private void OnLoginFailure(PlayFabError error)
    {
        go_panel_login.SetActive(false);
        go_panel_error.SetActive(true);
        Debug.LogWarning("no hay mano");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }


    public void NuevoRegistro()
    {
        SceneManager.LoadScene("Scenes/RegisterScene");
    }


}

