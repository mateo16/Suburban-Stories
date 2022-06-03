
namespace DapperDino.Items{
    public interface IItemContainer
{
    ItemSlot AddItem(ItemSlot ItemSlot);

    void RemoveItem(ItemSlot ItemSlot);
    void RemoveAt(int slotIndex);

    void Swap(int indexOne, int indexTwo);
    
    bool HasItem(InventoryItem item);

    int GetTotalQuantity(InventoryItem item);
}
}

