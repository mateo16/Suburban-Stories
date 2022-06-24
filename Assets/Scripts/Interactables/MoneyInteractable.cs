using UnityEngine;

namespace DapperDino.Interactables
{
    public class MoneyInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private Money moneyScript;
        public int value;

        public void Interact()
        {
            moneyScript.updateMoney(value);
        }
    }
}

