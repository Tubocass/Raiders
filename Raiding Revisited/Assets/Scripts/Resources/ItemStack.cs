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

        public ItemStack Combine(ItemStack other)
        {
            if(quantity + other.Quantity <= itemType.stackLimit)
            {
                quantity += other.Quantity;
                other.quantity = 0;
            }else
            {
                int diff = itemType.stackLimit - quantity;
                quantity += diff;
                other.quantity -= diff;
            }
            return other;
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

        public bool IsFull()
        {
            return Type != null && quantity == Type.stackLimit;
        }
    }
}