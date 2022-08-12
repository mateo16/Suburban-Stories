using UnityEngine;
using System;
using SuburbanStories.Events;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DapperDino.Items{



    public class Inventory : MonoBehaviour , IItemContainer
    {
        [SerializeField] private int money = 100;
        [SerializeField] private HandShow hand = null;
        [SerializeField] private UnityEvent onInventoryItemsUpdated = null;

        [SerializeField] private ItemSlot[] itemSlots = new ItemSlot[0];

        public int Money { get { return money; } set { money = value; } }

        public ItemSlot GetSlotByIndex(int index) => itemSlots[index];

        public ItemSlot AddItemHoldable(ItemSlot itemSlot)
        {
            if (itemSlot.item.Holdable)
            {
                if (itemSlots[20].item != null)
                {
                    if (itemSlots[20].item == itemSlot.item)
                    {
                        int slotRemainingSpace = itemSlots[20].item.MaxStack - itemSlots[20].quantity;
                        if (itemSlot.quantity <= slotRemainingSpace)
                        {
                            itemSlots[20].quantity += itemSlot.quantity;

                            itemSlot.quantity = 0;

                            onInventoryItemsUpdated.Invoke();

                            return itemSlot;
                        }
                        else if (slotRemainingSpace > 0)
                        {
                            itemSlots[20].quantity += slotRemainingSpace;
                            itemSlot.quantity -= slotRemainingSpace;
                        }
                    }
                }
                else if (itemSlots[20].item == null)
                {
                    if (itemSlot.quantity <= itemSlot.item.MaxStack)
                    {
                        itemSlots[20] = itemSlot;

                        itemSlot.quantity = 0;

                        onInventoryItemsUpdated.Invoke();

                        hand.ChangePrefab(itemSlot.item.name);

                        return itemSlot;
                    }
                    else
                    {
                        itemSlots[20] = new ItemSlot(itemSlot.item, itemSlot.item.MaxStack);

                        itemSlot.quantity -= itemSlot.item.MaxStack;

                        hand.ChangePrefab(itemSlot.item.name);
                    }
                }
            }
            ItemSlot slotItem = AddItem(itemSlot);
            return slotItem;
        }

        public ItemSlot AddItem(ItemSlot itemSlot)
        {

            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].item != null)
                {
                    if (itemSlots[i].item == itemSlot.item)
                    {
                        int slotRemainingSpace = itemSlots[i].item.MaxStack - itemSlots[i].quantity;
                        if (itemSlot.quantity <= slotRemainingSpace)
                        {
                            itemSlots[i].quantity += itemSlot.quantity;

                            itemSlot.quantity = 0;

                            onInventoryItemsUpdated.Invoke();

                            return itemSlot;
                        }
                        else if (slotRemainingSpace > 0)
                        {
                            itemSlots[i].quantity += slotRemainingSpace;
                            itemSlot.quantity -= slotRemainingSpace;
                        }
                    }
                }
            }

            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].item == null)
                {
                    if (itemSlot.quantity <= itemSlot.item.MaxStack)
                    {
                        itemSlots[i] = itemSlot;

                        itemSlot.quantity = 0;

                        onInventoryItemsUpdated.Invoke();

                        return itemSlot;
                    }
                    else
                    {
                        itemSlots[i] = new ItemSlot(itemSlot.item, itemSlot.item.MaxStack);

                        itemSlot.quantity -= itemSlot.item.MaxStack;
                    }
                }
            }
            onInventoryItemsUpdated.Invoke();

            return itemSlot;
        }

        public int GetTotalQuantity(InventoryItem item)
        {
            int totalCount = 0;

            foreach (ItemSlot itemSlot in itemSlots)
            {
                if (itemSlot.item == null) { continue; }
                if (itemSlot.item != item) { continue; }

                totalCount += itemSlot.quantity;
            }

            return totalCount;
        }

        public bool HasItem(InventoryItem item)
        {
            foreach (ItemSlot itemSlot in itemSlots)
            {
                if (itemSlot.item == null) { continue; }
                if (itemSlot.item != item) { continue; }
                return true;
            }
            return false;
        }

        public void RemoveAt(int slotIndex)
        {
            if (slotIndex < 0 || slotIndex > itemSlots.Length - 1) { return; }
            itemSlots[slotIndex] = new ItemSlot();

            onInventoryItemsUpdated.Invoke();
        }

        public List<InventoryItem> GetAllUniqueItems()
        {
            List<InventoryItem> items = new List<InventoryItem>();

            for (int i = 0; i < itemSlots.Length; i++)
            {
                if(itemSlots[i].item == null) { continue; }
                if (items.Contains(itemSlots[i].item)) { continue; }
                items.Add(itemSlots[i].item);
            }
            return items;
        }

        public void RemoveItem(ItemSlot itemSlot)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].item != null)
                {
                    if (itemSlots[i].item == itemSlot.item)
                    {
                        if (itemSlots[i].quantity < itemSlot.quantity)
                        {
                            itemSlot.quantity -= itemSlots[i].quantity;

                            itemSlots[i] = new ItemSlot();
                        }
                        else
                        {
                            itemSlots[i].quantity -= itemSlot.quantity;

                            if (itemSlots[i].quantity == 0)
                            {
                                itemSlots[i] = new ItemSlot();

                                onInventoryItemsUpdated.Invoke();

                                return;
                            }
                        }
                    }
                }
            }
        }

        public void HoldableSwap(int indexOne, int indexTwo)
        {
            ItemSlot firstSlot = itemSlots[indexOne];
            ItemSlot secondSlot = itemSlots[indexTwo];

            if (firstSlot.Equals(secondSlot)) { return; }

            if (secondSlot.item != null)
            {
                if (firstSlot.item == secondSlot.item)
                {
                    int secondSlotRemainingSpace = secondSlot.item.MaxStack - secondSlot.quantity;

                    if (firstSlot.quantity <= secondSlotRemainingSpace)
                    {
                        itemSlots[indexTwo].quantity += firstSlot.quantity;

                        itemSlots[indexOne] = new ItemSlot();

                        onInventoryItemsUpdated.Invoke();

                        return;
                    }
                }
            }

            itemSlots[indexOne] = secondSlot;
            itemSlots[indexTwo] = firstSlot;

            if(indexOne == 20 )
            {
                if(secondSlot.item != null )
                {
                    if (secondSlot.item.Holdable)
                    {
                        hand.ChangePrefab(secondSlot.item.name);
                    }
                    else
                    {
                        hand.ChangePrefab("");
                    }
                }
                else
                {
                    hand.ChangePrefab("");
                }
                
            }
            else if(indexTwo == 20)
            {
                if (firstSlot.item != null)
                {
                    if (firstSlot.item.Holdable) {
                        hand.ChangePrefab(firstSlot.item.name);
                    }else
                    {
                        hand.ChangePrefab("");
                    }
                }
                else
                {
                    hand.ChangePrefab("");
                }
            }

            onInventoryItemsUpdated.Invoke();
        }

        public void Swap(int indexOne, int indexTwo)
        {
            ItemSlot firstSlot = itemSlots[indexOne];
            ItemSlot secondSlot = itemSlots[indexTwo];

            if (firstSlot.Equals(secondSlot)) { return; }

            if (secondSlot.item != null)
            {
                if (firstSlot.item == secondSlot.item)
                {
                    int secondSlotRemainingSpace = secondSlot.item.MaxStack - secondSlot.quantity;

                    if (firstSlot.quantity <= secondSlotRemainingSpace)
                    {
                        itemSlots[indexTwo].quantity += firstSlot.quantity;

                        itemSlots[indexOne] = new ItemSlot();

                        onInventoryItemsUpdated.Invoke();

                        return;
                    }
                }
            }

            itemSlots[indexOne] = secondSlot;
            itemSlots[indexTwo] = firstSlot;

            onInventoryItemsUpdated.Invoke();
        }
    }
}

