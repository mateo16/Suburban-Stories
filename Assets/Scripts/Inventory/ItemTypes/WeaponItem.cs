using System.Text;
using UnityEngine;

namespace DapperDino.Items
{

    [CreateAssetMenu(fileName = "New Weapon Item", menuName = "Items/Weapon Item")]

    public class WeaponItem : InventoryItem
    {
        [Header("Weapon Data")]
        [SerializeField] private int maxAmmo = 1;

        public override string GetInfoDisplayText()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Max Ammo: ").Append(maxAmmo).AppendLine();
            builder.Append("Sell Price").Append(SellPrice).Append(" Gold");

            return builder.ToString();
        }
    }
}

