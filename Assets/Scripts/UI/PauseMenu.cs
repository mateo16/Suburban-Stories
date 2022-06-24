using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    private PlayerData playerData;
    public static bool schoolMode;

    private void Start()
    {
        playerData = new PlayerData();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void SaveOnline()
    {
        playerData.health = HealthBar.currentHealth;
        playerData.WorldName = MainMenu.currentWorldName;
        if(playerData.WorldName != null)
        {
            Debug.Log("funciono");
            FindObjectOfType<FireBase>().PostToDatabase(playerData);
        }
        else
        {
            Debug.Log("El mundo no tiene nombre");
        }
    }
    public void Settings()
    {

    }
    public void SchoolMode()
    {
        if (schoolMode)
        {
            schoolMode = false;
        }
        else
        {
            schoolMode = true;
        }
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
