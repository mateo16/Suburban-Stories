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
    public GameObject loadingScreen;
    public Slider slider;
    public AudioManager audioo;
    public GameObject ClickSoundEffect;

    public void Start()
    {
        audioo.Play("Theme");
    }

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("ClickSoundEffect");
        if(createWorldName.text.Trim() != "") {
            currentWorldName = createWorldName.text.Trim();
            StartCoroutine(LoadScene());
        }
        else
        {
            Debug.Log("No se puede poner un nombre vacio");
        }
    }

    public void LoadGame()
    {
        FindObjectOfType<AudioManager>().Play("ClickSoundEffect");
        if (loadWorldName.text.Trim() != "")
        {
            currentWorldName = loadWorldName.text.Trim();
            FindObjectOfType<FireBase>().GetToDatabase(currentWorldName);
            StartCoroutine(LoadScene());
        }
        else
        {
            Debug.Log("No se puede poner un nombre vacio");
        }
    }

    IEnumerator LoadScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("ClickSoundEffect");
        Debug.Log("Quit");
        Application.Quit();
    }
}
