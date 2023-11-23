using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Logout()
    {
        PlayerPrefs.DeleteKey("PLAYER_EMAIL");
        PlayerPrefs.DeleteKey("PLAYER_PASSWORD");
        SceneManager.LoadScene("Scenes/LoginScene");
    }

}
