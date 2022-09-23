using DapperDino.Items;
using UnityEngine;
using SuburbanStories.Events;

namespace DapperDino.Npcs.Occupations.Vendors
{
    public class Vendor : MonoBehaviour, IOccupation
    {
        [SerializeField] private VendorDataEvent onStartVendorScenario = null;
        public string Name => "Vendor";

        private IItemContainer itemContainer = null;

        private void Start() => itemContainer = GetComponent<IItemContainer>();

        public void Trigger(GameObject other)
        {
            questSystemTrucho.questNumber = 4;
            Cursor.lockState = CursorLockMode.None;
            var otherItemContainer = other.GetComponent<IItemContainer>();
            if (otherItemContainer == null) { return; }
            VendorData vendorData = new VendorData(otherItemContainer,itemContainer);

            onStartVendorScenario.Raise(vendorData);

        }
    }
}

