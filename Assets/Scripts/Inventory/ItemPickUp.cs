using UnityEngine;
using DapperDino.Interactables;

namespace DapperDino.Items
{
    public class ItemPickUp : MonoBehaviour, IInteractable
    {

        [SerializeField] private ItemSlot itemSlot;

        public bool Interact(GameObject other)
        {
            var itemContainer = other.GetComponent<Inventory>();

            if (itemContainer == null) { return true; }

            if(itemContainer.AddItemHoldable(itemSlot).quantity == 0)
            {
                Destroy(gameObject);
                return false;
            }
            return true;
        }
    }
}


