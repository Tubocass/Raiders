using System.Collections;
using UnityEngine;
using RaidingParty.Resources;

namespace RaidingParty.Buildings
{
    public class StorageSlot : MonoBehaviour
    {
        /*
         *  holds stack of items
         *  ItemType storedItem
         *  int quantity
        */
        public ItemStack stack;

        public void Fill(ItemStack fillStack)
        {
            if(stack.Type != null)
            {
                if (stack.Type == fillStack.Type)
                {
                    stack.Combine(fillStack);
                }
            }else
            {
                stack = fillStack;
            }
            Debug.Log("total: " + stack.Quantity);
        }

        public ItemStack Pull(int amount)
        {
            ItemStack pullStack = stack.Split(amount);
            
            if(stack.Quantity < 1)
            {
                stack = null;
            }

            return pullStack;
        }

        public bool IsEmpty()
        {
            return stack.Type == null;
        }

        public bool IsFull()
        {
            return !IsEmpty() && stack.Quantity == stack.Type.stackLimit;
        }

        public ItemType GetItemType()
        {
            return stack != null ? stack.Type : null;
        }
    }
}