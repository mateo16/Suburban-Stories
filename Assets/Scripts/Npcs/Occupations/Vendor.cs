using DapperDino.Items;
using UnityEngine;
using System.Collections.Generic;

namespace DapperDino.Npcs.Occupations
{
    public class Vendor : MonoBehaviour, IOccupation
    {
        public string Name => "Vendor";

        private IItemContainer itemContainer = null;

        private void Start() => itemContainer = GetComponent<IItemContainer>();

        public void Trigger()
        {
            Cursor.lockState = CursorLockMode.None;
            string itemNames = "";
            List<Item> items = itemContainer.GetAllItems();
            for (int i = 0; i < items.Count; i++)
            {
                itemNames += $"{ items[i].name}, ";
            }
            Debug.Log(itemNames);
        }
    }
}

