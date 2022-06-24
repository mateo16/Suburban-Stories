using UnityEngine;
using TMPro;


public class Money : MonoBehaviour
{
    public int startMoney = 0;
    public int currentMoney;
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        currentMoney = startMoney;
        moneyText.text = startMoney.ToString();
    }

    public void updateMoney(int moneyToChange)
    {
        if(currentMoney + moneyToChange < 0)
        {
            currentMoney = 0;
        }
        else
        {
            currentMoney += moneyToChange;
        }
        moneyText.text = currentMoney.ToString();
    }
}
