using UnityEngine;
using DapperDino.Interactables;

namespace DapperDino.Items
{
    public class Chest : MonoBehaviour, IInteractable
    {

        [SerializeField] private Inventory inventory;
        [SerializeField] private GameObject ChestCanvas;

        public bool Interact(GameObject other)
        {
            ChestCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            return true;
        }
    }
}

