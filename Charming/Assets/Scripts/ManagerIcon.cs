using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerIcon : MonoBehaviour
{
    public List<Sprite> Sprites;

    public static ManagerIcon instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public Sprite LoadSprite(Items items)
    {
        // for all sprite avaible 
        for (int i = 0; i < Sprites.Count - 1; i++)
        {
            // if the sprie name is equal to this name sprite
            if (items.SpriteName == Sprites[i].name)
            {
                return Sprites[i];
            }
        }
        return null;
    }
}
