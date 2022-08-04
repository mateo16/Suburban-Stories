using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public int AmmoLeft;
    int MagazineSize;
    public Text AmmoText;
    bool HeldGun = false;
    public static bool showAmmo = false;

    void Start()
    {

    }
    public void StartAmmo(int AmmoAmount , int bulletsLeft){
        MagazineSize = AmmoAmount;
        AmmoLeft = bulletsLeft;
        AmmoText.text = AmmoLeft + "/" + MagazineSize;
        HeldGun = true;
    }
    void Update()
    {
        if(showAmmo){
            AmmoText.enabled = true;
        }else{
            AmmoText.enabled = false;
        }
    }

    public void ReduceAmmo()
    {
        AmmoLeft--;
        AmmoText.text = AmmoLeft + "/" + MagazineSize;
    }
    public void RestartAmmo(int AmmoAmount)
    {
        AmmoLeft = AmmoAmount;
        AmmoText.text = AmmoLeft + "/" + MagazineSize;
    }
}
