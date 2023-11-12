using System.Collections;
using UnityEngine;
using RaidingParty.Resources;

namespace RaidingParty.Buildings
{
    public class StorageSlot : MonoBehaviour
    {
        [SerializeReference] public ItemStack stack;

        private void OnDestroy()
        {
            //stack = null;
        }
        public ItemStack Fill(ItemStack fillStack)
        {
            ItemStack leftover = null;
            if(stack != null)
            {
                if(stack.Type == fillStack.Type && stack.Quantity < stack.Type.stackLimit)
                {
                    leftover = stack.Combine(fillStack);
                }
            }
            else
            {
                stack = fillStack;
            }
            Debug.Log("total: " + stack.Quantity);
            return leftover;
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
            return stack == null;
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