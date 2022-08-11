using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public int AmmoLeft;
    int MagazineSize;
    public Text AmmoText;
    public GameObject CrossHair;
    bool HeldGun = false;
    public static bool showCrossHair = false;
    public static bool showAmmo = false;

    void Start()
    {
        //AmmoText.transform.Find("CrossHair");
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
        if(showCrossHair)
        {
            CrossHair.SetActive(true);
        }
        else
        {
            CrossHair.SetActive(false);
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
