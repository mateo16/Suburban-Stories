using UnityEngine;

namespace DapperDino.Items.Inventories
{
    public class InventoryBehaviour : MonoBehaviour , IItemContainer
    {
        [SerializeField] private Inventory inventory = null;
        [SerializeField] private HandShow handShow = null;

        private void Start()
        {
            inventory.SetSize(21);
        }

        public ItemSlot AddItem(ItemSlot itemSlot) => inventory.AddItemHoldable(itemSlot,handShow);

        public int GetTotalQuantity(InventoryItem item) => inventory.GetTotalQuantity(item);

        public bool HasItem(InventoryItem item) => inventory.HasItem(item);

        public void RemoveAt(int slotIndex) => inventory.RemoveAt(slotIndex);

        public void RemoveItem(ItemSlot itemSlot) => inventory.RemoveItem(itemSlot);

        public void Swap(int indexOne, int indexTwo) => inventory.HoldableSwap(indexOne, indexTwo, handShow);
    }
}

