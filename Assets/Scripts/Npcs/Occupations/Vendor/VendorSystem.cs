using DapperDino.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DapperDino.Npcs.Occupations.Vendors
{
    public class VendorSystem : MonoBehaviour
    {
        [SerializeField] private GameObject buttonPrefab = null;
        [SerializeField] private Transform buttonHolderTransform = null;
        [SerializeField] private Money moneyScript = null;

        [Header("Data Display")]
        [SerializeField] private TextMeshProUGUI itemNameText = null;
        [SerializeField] private TextMeshProUGUI itemDescriptionText = null;
        [SerializeField] private TextMeshProUGUI itemDataText = null;

        [Header("Quantity Display")]
        [SerializeField] private TextMeshProUGUI quatityText = null;
        [SerializeField] private Slider quantitySlider = null;

        private VendorData scenarioData = null;
        private InventoryItem currentItem;
        public void StartScenario(VendorData scenarioData) {
            this.scenarioData = scenarioData;
            SetCurrentItemContainer(true);
            
        }
        public void SetItem(InventoryItem item)
        {
            currentItem = item;
            if(item == null)
            {
                itemNameText.text = string.Empty;
                itemDescriptionText.text = string.Empty;
                itemDataText.text = string.Empty;
                return;
            }
            itemNameText.text = item.Name;
            itemDescriptionText.text = item.Description;
            itemDataText.text = item.GetInfoDisplayText();

            int totalQuantity = scenarioData.SellingItemContainer.GetTotalQuantity(item);
            quatityText.text = $"0/{totalQuantity}";
            quantitySlider.maxValue = totalQuantity;
            quantitySlider.value = 0;
        }
        public void UpdateSliderText(float quantity)
        {
            int totalQuantity = scenarioData.SellingItemContainer.GetTotalQuantity(currentItem);
            quatityText.text = $"{quantity}/{totalQuantity}";
        }
        public void ConfirmButton()
        {
            int price = currentItem.SellPrice * (int)quantitySlider.value;


                scenarioData.BuyingItemContainer.Money -= price;
                scenarioData.SellingItemContainer.Money += price;

                var itemSlotSwap = new ItemSlot(currentItem, (int)quantitySlider.value);
                scenarioData.BuyingItemContainer.AddItem(itemSlotSwap);
                scenarioData.SellingItemContainer.RemoveItem(itemSlotSwap);

            moneyScript.UpdateDisplay();

        }
        private void ClearItemButtons()
        {
            foreach(Transform child in buttonHolderTransform)
            {
                Destroy(child.gameObject);
            }
        }
        public void SetCurrentItemContainer(bool isFirst)
        {
            ClearItemButtons();
            scenarioData.IsFirstContainerBuying = isFirst;
            var items = scenarioData.SellingItemContainer.GetAllUniqueItems();
            for (int i = 0; i < items.Count; i++)
            {
                GameObject buttonInstance = Instantiate(buttonPrefab, buttonHolderTransform);
                buttonInstance.GetComponent<VendorItemButton>().Initialise(this, items[i], scenarioData.SellingItemContainer.GetTotalQuantity(items[i]));
            }
            SetItem(scenarioData.SellingItemContainer.GetSlotByIndex(0).item);
        }
}
}

