using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public InputField createWorldName;
    public InputField loadWorldName;
    public static string currentWorldName;

    public void PlayGame()
    {
        if(createWorldName.text.Trim() != "") {
            currentWorldName = createWorldName.text.Trim();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("No se puede poner un nombre vacio");
        }
    }

    public void LoadGame()
    {
        if (loadWorldName.text.Trim() != "")
        {
            currentWorldName = loadWorldName.text.Trim();
            FindObjectOfType<FireBase>().GetToDatabase(currentWorldName);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("No se puede poner un nombre vacio");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
