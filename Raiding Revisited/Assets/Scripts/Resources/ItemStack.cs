using System.Collections;
using UnityEngine;

namespace RaidingParty.Resources
{
    public class ItemStack : MonoBehaviour
    {
        private ItemType itemType;
        private int quantity;
        public ItemStack(ItemType type, int quantity)
        {
            this.itemType = type;
            this.quantity = quantity;
        }

        public ItemType Type { get { return itemType; } }
        public int Quantity { get { return quantity; } }

        public void Combine(ItemStack other)
        {
            if(quantity + other.Quantity < itemType.stackLimit)
            {
                quantity += other.Quantity;
            }
        }

        public ItemStack Split(int amount)
        {
            ItemStack split;

            if (amount < quantity)
            {
                split = new ItemStack(itemType, amount);
                quantity -= amount;
            }else
            {
                split = new ItemStack(itemType, quantity);
                quantity = 0;
            }

            return split;
        }
    }
}