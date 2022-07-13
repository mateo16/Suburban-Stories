using System.Text;
using UnityEngine;

namespace DapperDino.Items
{

    [CreateAssetMenu(fileName = "New Default Item", menuName = "Items/Default Item")]

    public class DefaultItem : InventoryItem
    {


        public override string GetInfoDisplayText()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Max Stack: ").Append(MaxStack).AppendLine();
            builder.Append("Sell Price").Append(SellPrice).Append(" Gold");

            return builder.ToString();
        }
    }
}