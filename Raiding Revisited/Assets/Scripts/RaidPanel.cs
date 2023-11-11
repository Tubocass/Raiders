using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace RaidingParty
{
    public class RaidPanel : MonoBehaviour
    {
        /*  Raid Props
        *      Ship
        *      Captain
        *      Main Crew
        *      Destination
        */
        [SerializeField] List<TMP_Dropdown> dropdowns;
        [SerializeField] Sprite testSprite;

        public void createRaid()
        {
            List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData("Test", testSprite);
            options.Add(option);
            dropdowns[0].AddOptions(options);
            Image optionImage = GetComponentInChildren<Image>(true);
            optionImage = dropdowns[0].itemImage;
        }

        private void OnEnable()
        {
            createRaid();
        }
    }
}