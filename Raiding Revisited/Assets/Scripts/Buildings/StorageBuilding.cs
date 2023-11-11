using System.Collections;
using UnityEngine;
using RaidingParty.Resources;

namespace RaidingParty.Buildings
{
    public class StorageBuilding : MonoBehaviour, BuildingInterface
    {
        /*
         *  StorageSlot[] slots
         *  Store(ItemType, int)
         *  Collect(ItemType, int)
        */

        StorageSlot[] slots = new StorageSlot[6];
        public bool Store(ItemStack item)
        {
            for(int s = 0; s < slots.Length; s++)
            {
                if (slots[s].IsEmpty())
                {
                    slots[s].Fill(item);
                    return true;
                }
            }
            return false;
        }

        public ItemStack Collect(ItemType item, int amount)
        {
            // get ItemStack from storageSlots
            // call stack.Split(amount)
            for (int s = 0; s < slots.Length; s++)
            {
                if(slots[s].itemType == item)
                {

                }
            }
                ItemStack split = new ItemStack(item, amount);
            return split;
        }
    }
}