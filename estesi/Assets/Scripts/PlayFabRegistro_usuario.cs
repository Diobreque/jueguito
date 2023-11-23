using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayFabRegistro_usuario : MonoBehaviour
{
    // Definimos variables de objeto para InputField
    public InputField reg_user;
    public InputField reg_display;
    public InputField reg_email;
    public InputField reg_password;

    public void Registro_usuario()
    {
        string user_nickname = reg_user.text;
        string user_display = reg_display.text;
        string user_email = reg_email.text;
        string user_password = reg_password.text;
        var request = new PlayFab.ClientModels.RegisterPlayFabUserRequest 
        {
            Email = user_email, Password = user_password, Username = user_nickname, DisplayName = user_display
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, RegisterSuccess, RegisterError);
    }
    private void RegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("****** Registro exitoso! ******");
        SceneManager.LoadScene("Scenes/LoginScene");
    }

    private void RegisterError(PlayFabError error)
    {
        Debug.LogWarning("Usuario o Contraseña incorretos");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }


    public void Volver()
    {
        SceneManager.LoadScene("Scenes/LoginScene");
    }
}
