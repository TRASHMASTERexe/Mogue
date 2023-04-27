using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{


    public Sprite Sprite;
    public abstract string ItemName { get;}
    public abstract Rarity Rarity { get; }
    public abstract Target Target { get; }

    public abstract void Effect(EnemyStatBlock statBlock);
}
