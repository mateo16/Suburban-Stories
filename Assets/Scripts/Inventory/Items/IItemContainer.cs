
using System.Collections.Generic;

namespace DapperDino.Items{

    public interface IItemContainer
{
     ItemSlot GetSlotByIndex(int index);

    ItemSlot AddItem(ItemSlot ItemSlot);

    List<InventoryItem> GetAllUniqueItems();

    void RemoveItem(ItemSlot ItemSlot);
    void RemoveAt(int slotIndex);

    void Swap(int indexOne, int indexTwo);
    
    bool HasItem(InventoryItem item);

    int GetTotalQuantity(InventoryItem item);
}
}

