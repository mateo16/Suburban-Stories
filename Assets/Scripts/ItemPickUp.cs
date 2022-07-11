using UnityEngine;
using DapperDino.Interactables;

namespace DapperDino.Items
{
    public class ItemPickUp : MonoBehaviour, IInteractable
    {

        [SerializeField] private ItemSlot itemSlot;

        public void Interact(GameObject other)
        {
            var itemContainer = other.GetComponent<IItemContainer>();

            if (itemContainer == null) { return; }

            if(itemContainer.AddItem(itemSlot).quantity == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}


