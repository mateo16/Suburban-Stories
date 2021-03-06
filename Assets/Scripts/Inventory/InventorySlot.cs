using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DapperDino.Items
{
    public class InventorySlot : ItemSlotUI, IDropHandler
    {
        [SerializeField] private Inventory inventory = null;
        [SerializeField] private TextMeshProUGUI itemQuantitytext = null;
        [SerializeField] private HandShow handShow = null;

        public override HotbarItem SlotItem
        {
            get { return ItemSlot.item; }
            set { }
        }
        public ItemSlot ItemSlot => inventory.GetSlotByIndex(SlotIndex);

        public override void OnDrop(PointerEventData eventData)
        {
            ItemDragHandler itemDragHandler = eventData.pointerDrag.GetComponent<ItemDragHandler>();

            if(itemDragHandler == null) { return;}

            if ((itemDragHandler.ItemSlotUI as InventorySlot) != null)
            {
                inventory.HoldableSwap(itemDragHandler.ItemSlotUI.SlotIndex, SlotIndex ,handShow);
            }
        }

        public override void UpdateSlotUI()
        {
            if(ItemSlot.item == null)
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

