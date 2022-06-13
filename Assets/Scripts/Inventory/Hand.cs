using UnityEngine;
using System;
using SuburbanStories.Events;

namespace DapperDino.Items{

    [CreateAssetMenu(fileName ="New Hand",menuName ="Items/Hand")]
    public class Hand : ScriptableObject
    {
        [SerializeField] private VoidEvent onInventoryItemsUpdated = null;
        [SerializeField] private ItemSlot testItemSlot = new ItemSlot();

        public ItemContainer ItemContainer { get; } = new ItemContainer(1);

        public void OnEnable() => ItemContainer.OnItemsUpdated += onInventoryItemsUpdated.Raise;

        public void OnDisable() => ItemContainer.OnItemsUpdated -= onInventoryItemsUpdated.Raise;

        [ContextMenu("Test Add")]
        public void TestAdd()
        {
            ItemContainer.AddItem(testItemSlot);
        }

    }
}

