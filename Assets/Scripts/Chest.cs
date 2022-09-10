using UnityEngine;
using DapperDino.Interactables;
using SuburbanStories.Events;

namespace DapperDino.Items
{
    public class Chest : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject chestCanvas;
        [SerializeField] private GameObject inventoryCanvas;
        [SerializeField] private GameObject inventoryCanvas2;
        [SerializeField] private MouseLook scriptLook;
        [SerializeField] private VoidEvent DisableGunSystem;

        public bool Interact(GameObject other)
        {
            chestCanvas.SetActive(true);
            inventoryCanvas.SetActive(true);
            inventoryCanvas2.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            scriptLook.enabled = false;
            DisableGunSystem.Raise();
            return true;
        }
    }
}

