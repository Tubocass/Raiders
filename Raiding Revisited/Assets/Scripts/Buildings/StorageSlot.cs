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
        public ItemType itemType;

       public void Fill(ItemStack stack)
        {
            this.stack = stack;
            this.itemType = stack.Type;
        }

        public ItemStack EmptySlot()
        {
            ItemStack empty = stack;
            stack = null;
            return empty;
        }

        public bool IsEmpty()
        {
            return stack == null;
        }
    }
}