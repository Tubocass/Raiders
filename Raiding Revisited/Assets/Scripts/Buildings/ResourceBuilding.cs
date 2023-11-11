using System.Collections;
using UnityEngine;
using RaidingParty.Resources;

namespace RaidingParty.Buildings
{
    public class ResourceBuilding : MonoBehaviour, BuildingInterface
    {
        /*
         *  produces resource at some rate
         *  ItemType resource
         *  ItemType Produce()
        */
        public ItemType resourceType;
        [SerializeField] int quantity;

        public ItemStack Produce()
        {
            return new ItemStack(resourceType, quantity);
        }
    }
}