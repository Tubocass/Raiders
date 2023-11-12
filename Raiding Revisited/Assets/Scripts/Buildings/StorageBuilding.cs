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

        private void Awake()
        {
            slots = GetComponentsInChildren<StorageSlot>();
        }
        public bool Store(ItemStack item)
        {
            for(int s = 0; s < slots.Length; s++)
            {
                // check for combine first
                if (!slots[s].IsFull() && slots[s].GetItemType() == item.Type)
                {
                    if(slots[s].Fill(item).Quantity == 0)
                    {
                        return true;
                    }
                }
                else if (slots[s].IsEmpty())
                {
                    slots[s].Fill(item);
                    return true;
                }
            }
            return false;
        }

        public ItemStack Collect(ItemType type, int amount)
        {
            //  pull from as many slots as needed
            ItemStack collection = new ItemStack(type, 0);
            for (int s = 0; s < slots.Length; s++)
            {
                if(slots[s].GetItemType() == type)
                {
                    collection.Combine(slots[s].Pull(amount - collection.Quantity));
                    if (collection.Quantity == amount)
                    {
                        return collection;
                    }
                }
            }
            return collection.Quantity > 0 ? collection : null;
        }
    }
}