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

    public void singleplayerFunction()
    {
        Debug.Log("sp");
        SceneManager.LoadScene("SP");
    }
    public void multiplayerSelectFunction()
    {
        Debug.Log("mp select");
        SceneManager.LoadScene("MultiPlayerSelection");
    }
    public void settingsFunction()
    {
        Debug.Log("settings");
        SceneManager.LoadScene("Settings");
    }
    public void exitFunction()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    public void mp()
    {
        SceneManager.LoadScene("MP");
    }
    public void MainMenuS()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
