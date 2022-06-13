using UnityEngine.EventSystems;
using UnityEngine;

namespace DapperDino.Items
{
    public class HotbarItemDragHandler : ItemDragHandler
    {
        [SerializeField] private ItemThrower itemThrower = null;

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                base.OnPointerUp(eventData);

                if (eventData.hovered.Count == 0)
                {
                    HotbarSlot thisSlot = ItemSlotUI as HotbarSlot;
                    itemThrower.Activate(thisSlot.ItemSlot, thisSlot.SlotIndex);
                }
            }

        }
    }
}


