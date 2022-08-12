using UnityEngine;
using DapperDino.Interactables;

namespace DapperDino.Items
{
    public class Chest : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject chestCanvas;
        [SerializeField] private GameObject inventoryCanvas;
        [SerializeField] private GameObject inventoryCanvas2;

        public bool Interact(GameObject other)
        {
            chestCanvas.SetActive(true);
            inventoryCanvas.SetActive(true);
            inventoryCanvas2.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            return true;
        }
    }
}

