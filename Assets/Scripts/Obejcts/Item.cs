using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    public Sprite img;
    public Rarity rarity;
    public Target Target;

    public abstract string itemName { get;}

    public abstract void Effect(StatBlock statBlock);
}
