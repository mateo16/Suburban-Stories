using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DapperDino.Items{
    public interface ItemContainer
{
    ItemSlot AddItem(ItemSlot ItemSlot);

    void RemoveItem(ItemSlot ItemSlot);
    void RemoveAt(int slotIndex);

    void Swap(int indexOne, int indexTwo);
}
}

