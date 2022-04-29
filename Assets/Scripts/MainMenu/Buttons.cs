using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private ManagerJuego _managerjuego;
    [SerializeField] private string newGameLevel = "Level1";

    public void PlayGame()
    {
        
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
