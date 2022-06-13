using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DapperDino.Items
{
    public class Hotbar : MonoBehaviour
    {
        [SerializeField] private HotbarSlot[] hotbarSlots = new HotbarSlot[1];
        public void Add(HotbarItem itemToAdd)
        {
            foreach (HotbarSlot hotbarSlot in hotbarSlots)
            {
               // if (hotbarSlot.AddItem(itemToAdd)) { return; }
            }
    }
    }

}
