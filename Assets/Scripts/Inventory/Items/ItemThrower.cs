using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DapperDino.Items
{
    public class ItemThrower : MonoBehaviour
    {
        [SerializeField] private Inventory inventory = null;

        private int slotIndex = 0;

        private void OnDisable() => slotIndex = -1;

        public void Activate(ItemSlot itemSlot, int slotIndex)
        {
            this.slotIndex = slotIndex;

            inventory.RemoveAt(slotIndex);

            //Instantiate item
        }
    }
}

