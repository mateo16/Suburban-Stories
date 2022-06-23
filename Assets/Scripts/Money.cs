using UnityEngine;
using TMPro;


public class Money : MonoBehaviour
{
    public int startMoney = 0;
    private int currentMoney;
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        currentMoney = startMoney;
        moneyText.text = startMoney.ToString();
    }

    public void updateMoney(int moneyToChange)
    {
        currentMoney += moneyToChange;
        moneyText.text = currentMoney.ToString();
    }
}
