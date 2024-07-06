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
        public GameObject prefab;
        public ItemType resourceType;
        [SerializeField] int quantity;

        public ItemStack Produce()
        {
            //Instantiate(prefab, transform.position, Quaternion.identity);
            return new ItemStack(resourceType, quantity);
        }
    }
}