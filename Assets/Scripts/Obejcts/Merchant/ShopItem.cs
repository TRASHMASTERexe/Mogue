using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{

    public int Index { get; private set; }
    public Item Item { get; private set; }
    public int Price { get; private set; }

    public ShopItem Builder(int index, Item item, int price)
    {
        Index = index;
        Item = item;
        Price = price;
        return this;
    }
}
