using UnityEngine;
using RaidingParty.Buildings;
using RaidingParty.Resources;

namespace RaidingParty
{
    public class GameController : MonoBehaviour
    {
        public int width, height;
        [SerializeField] SpriteRenderer protoCell;

        GridGenerator gridGenerator;
        SpriteRenderer[,] cellDisplays;

        private void Start()
        {
            gridGenerator = new GridGenerator(width, height);
            cellDisplays = new SpriteRenderer[width, height];
            gridGenerator.GenerateGrid();

            for(int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cellDisplays[x,y] = Instantiate(protoCell, new Vector3(x, y), Quaternion.identity);
                    
                }
            }
        }

    }
} 