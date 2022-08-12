using UnityEngine;
using TMPro;
using DapperDino.Items;

public class Money : MonoBehaviour
{
    public Inventory playerInventory;

    public TextMeshProUGUI moneyText;

    private void Start()
    {
        moneyText.text = playerInventory.Money.ToString();
    }

    public void updateMoney(int moneyToChange)
    {
        if(playerInventory.Money + moneyToChange < 0)
        {
            playerInventory.Money = 0;
        }
        else
        {
            playerInventory.Money += moneyToChange;
        }
        moneyText.text = playerInventory.Money.ToString();
    }
    public void UpdateDisplay()
    {
        moneyText.text = playerInventory.Money.ToString();
    }
}
