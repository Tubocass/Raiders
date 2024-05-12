using RaidingParty;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpriteMap : ScriptableObject
{
    public Sprite grass;
    public Sprite forest;
    public Sprite stone;
    public Sprite water;
    public Dictionary<LandType, Sprite> spriteMap;

    private void OnEnable()
    {
        spriteMap = new Dictionary<LandType, Sprite>
        {
            { LandType.Grass, grass },
            { LandType.Water, water },
            { LandType.Forest, forest },
            { LandType.Stone, stone }
        };
    }
}
