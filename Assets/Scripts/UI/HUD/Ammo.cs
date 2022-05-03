using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public int AmmoLeft = 8;
    public Text AmmoText;
    void Start()
    {
        
    }

    void Update()
    {
        AmmoText.text = AmmoLeft + " Bullets Left";
    }

    void ReduceAmmo()
    {
        AmmoLeft--;
    }
}
