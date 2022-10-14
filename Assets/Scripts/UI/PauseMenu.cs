using System.Collections;
using System.Collections.Generic;
using SuburbanStories.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    private PlayerData playerData;
    public static bool schoolMode;
    [SerializeField] private VoidEvent OnSchoolModeChange;

    private void Start()
    {
        schoolMode = false;
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
        FindObjectOfType<AudioManager>().Play("ClickSoundEffect");
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
        FindObjectOfType<AudioManager>().Play("ClickSoundEffect");
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
        FindObjectOfType<AudioManager>().Play("ClickSoundEffect");
    }
    public void SchoolMode()
    {
        FindObjectOfType<AudioManager>().Play("ClickSoundEffect");
        OnSchoolModeChange.Raise();
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
        FindObjectOfType<AudioManager>().Play("ClickSoundEffect");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("ClickSoundEffect");
        Application.Quit();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
