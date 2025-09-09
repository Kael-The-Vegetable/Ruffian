using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NumberSpriteLibrary", menuName = "Card Games/Number Sprite Library")]
public class NumberSpriteLibrary : ScriptableObject
{
    [field: SerializeField] public Sprite[] Sprites { get; private set; }

    public Sprite GetSprite(int index)
    {
        index = Math.Clamp(index, 0, Sprites.Length - 1);
        return Sprites[index];
    }
}
