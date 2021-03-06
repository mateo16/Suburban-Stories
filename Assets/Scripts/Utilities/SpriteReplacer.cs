using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteReplacer : MonoBehaviour
{
    public GameObject originalSprite;
    public GameObject schoolModeSprite;


    public void ChangeSprite()
    {
        if (!PauseMenu.schoolMode)
        {
            originalSprite.SetActive(false);
            schoolModeSprite.SetActive(true);
        }
        else
        {
            originalSprite.SetActive(true);
            schoolModeSprite.SetActive(false);
        }
    }
}
