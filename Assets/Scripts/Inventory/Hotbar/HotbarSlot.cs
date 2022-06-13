using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DapperDino.Items
{
    public class HotbarSlot : ItemSlotUI, IDropHandler
    {
        [SerializeField] private Inventory inventory = null;
        [SerializeField] private Hand hand = null;
        [SerializeField] private TextMeshProUGUI itemQuantitytext = null;

        public override HotbarItem SlotItem
        {
            get { return ItemSlot.item; }
            set { }
        }
        
        public ItemSlot ItemSlot => inventory.ItemContainer.GetSlotByIndex(20);

        public override void OnDrop(PointerEventData eventData)
        {

            ItemDragHandler itemDragHandler = eventData.pointerDrag.GetComponent<ItemDragHandler>();

            if (itemDragHandler == null) { return; }

            if ((itemDragHandler.ItemSlotUI as InventorySlot) != null)
            {
                inventory.ItemContainer.Swap(itemDragHandler.ItemSlotUI.SlotIndex, 20);
            }

            if ((itemDragHandler.ItemSlotUI as HotbarSlot) != null)
            {
                inventory.ItemContainer.Swap(itemDragHandler.ItemSlotUI.SlotIndex , 20);
            }
        }

        public override void UpdateSlotUI()
        {
            if (ItemSlot.item == null)
            {
                EnableSlotUI(false);
                return;
            }
            EnableSlotUI(true);

            itemIconImage.sprite = ItemSlot.item.Icon;
            itemQuantitytext.text = ItemSlot.quantity > 1 ? ItemSlot.quantity.ToString() : "";
        }

        protected override void EnableSlotUI(bool enable)
        {
            base.EnableSlotUI(enable);
            itemQuantitytext.enabled = enable;
        }
    }
}

