using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// This Function will bring us to single player screen
    /// </summary>
    public void singleplayerFunction()
    {
        Debug.Log("sp");
        SceneManager.LoadScene("SP1");
    }
    /// <summary>
    /// This Function will bring us to multiplayer selection screen
    /// </summary>
    public void multiplayerSelectFunction()
    {
        Debug.Log("mp select");
        SceneManager.LoadScene("MultiPlayerSelection");
    }
    /// <summary>
    /// This Function will bring us to settings screen
    /// </summary>
    public void settingsFunction()
    {
        Debug.Log("settings");
        SceneManager.LoadScene("Settings");
    }
    /// <summary>
    /// This Function will bring us out of the application
    /// </summary>
    public void exitFunction()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    /// <summary>
    /// This Function will bring us to multiplayer game
    /// </summary>
    public void mp()
    {
        SceneManager.LoadScene("MP");
    }
    /// <summary>
    /// This Function will bring us back to main menu
    /// </summary>
    public void MainMenuS()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
