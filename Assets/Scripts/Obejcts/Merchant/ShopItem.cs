using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public Item Item { get; private set; }
    public int Price { get; private set; }

    public ShopItem Builder(Item item, int price)
    {
        Item = item;
        Price = price;
        return this;
    }
}
