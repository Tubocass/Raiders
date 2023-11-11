using System.Collections;
using UnityEngine;

namespace RaidingParty.Resources
{
    [System.Serializable]
    public class ItemStack
    {
        [SerializeField] private ItemType itemType;
        [SerializeField] private int quantity;
        public ItemStack(ItemType type, int quantity)
        {
            this.itemType = type;
            this.quantity = quantity;
        }

        public ItemType Type { get { return itemType; } }
        public int Quantity { get { return quantity; } }

        public void Combine(ItemStack other)
        {
            if(quantity + other.Quantity <= itemType.stackLimit)
            {
                quantity += other.Quantity;
            }else
            {
                int diff = itemType.stackLimit - quantity;
                quantity += diff;
                other.quantity -= diff;
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