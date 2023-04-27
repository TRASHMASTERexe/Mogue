using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MerchantManager : ManagerBase
{
    private const int NUM_ITEMS = 5;
    public GameObject merchantPrefab;
    public Sprite merchantImage;
    private int multiplier = 1;

    private Dictionary<Rarity, int> priceIndex = new Dictionary<Rarity, int>()
    {
        {Rarity.common, 2},
        {Rarity.uncommon, 5},
        {Rarity.rare, 10},
        {Rarity.mythic, 20}
    };

    //Add lifespan to merchant? scales up with difficulty?
    public void InitMerchant()
    {
        calcMultiplier();

        List<ShopItem> shopItems = new();
        List<Item> items = itemManager.rollItems(NUM_ITEMS);

        GameObject go = Instantiate(merchantPrefab, contentBoxTransform);

        for(int i = 0; i < items.Count; i++)
        {
            Item curItem = items[i];
            int price = priceIndex.GetValueOrDefault(curItem.Rarity) * multiplier;

            shopItems.Add(go.AddComponent<ShopItem>().Builder(i, curItem, price));

            Image image = go.GetComponentsInChildren<Image>().Where(image => image.name.ToLower().StartsWith("itemimage") && image.transform.parent.parent.name.ToLower().EndsWith((i+1).ToString())).FirstOrDefault();
            image.sprite = curItem.Sprite;

            TMP_Text text = go.GetComponentsInChildren<TMP_Text>().Where(text => text.name.ToLower().StartsWith("text") && text.transform.parent.parent.name.ToLower().EndsWith((i + 1).ToString())).FirstOrDefault();
            text.text = price.ToString();

        }
        go.GetComponentsInChildren<Image>().Where(image => image.name.ToLower().StartsWith("merchantimage")).FirstOrDefault().sprite = merchantImage;
        go.GetComponent<MerchantInfoStorage>().ShopItems = shopItems;
    }

    private void calcMultiplier()
    {
        multiplier = (int) Math.Ceiling(difficulty / 4.00);
    }
}