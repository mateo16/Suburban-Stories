using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public int AmmoLeft;
    int MagazineSize;
    public Text AmmoText;
    bool HeldGun = false;

    void Start()
    {

    }
    public void StartAmmo(int AmmoAmount , int bulletsLeft){
        MagazineSize = AmmoAmount;
        AmmoLeft = bulletsLeft;
        HeldGun = true;
    }
    void Update()
    {
        if (HeldGun)
        {
            AmmoText.text = AmmoLeft + "/" + MagazineSize;
        }

        if(PickUpController.slotFull && PickUpController.isGunHold){
            AmmoText.enabled = true;
        }else{
            AmmoText.enabled = false;
        }
    }

    public void ReduceAmmo()
    {
        AmmoLeft--;
    }
    public void RestartAmmo(int AmmoAmount)
    {
        AmmoLeft = AmmoAmount;
    }
}
