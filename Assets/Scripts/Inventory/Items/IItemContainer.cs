
using System.Collections.Generic;

namespace DapperDino.Items{

    public interface IItemContainer
{
    int Money { get; set; }

     ItemSlot GetSlotByIndex(int index);

    ItemSlot AddItem(ItemSlot ItemSlot);

    List<InventoryItem> GetAllUniqueItems();

    void RemoveItem(ItemSlot ItemSlot);
    void RemoveAt(int slotIndex);

    void Swap(int indexOne, int indexTwo, Inventory otherInventory);
    
    bool HasItem(InventoryItem item);

    int GetTotalQuantity(InventoryItem item);
}
}

