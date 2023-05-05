using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MerchantManager : ManagerBase
{
    private const int NUM_ITEMS = 4;
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

        List<Item> items = itemManager.rollItems(NUM_ITEMS);

        GameObject go = Instantiate(merchantPrefab, contentBoxTransform);

        for(int i = 0; i < items.Count; i++)
        {
            MerchantInfoStorage mis = go.GetComponentsInChildren<MerchantInfoStorage>().Where(button => button.name.ToLower().StartsWith("shopitem " + i)).FirstOrDefault();

            Item curItem = items[i];
            int price = priceIndex.GetValueOrDefault(curItem.Rarity) * multiplier;

            mis.ShopItem = mis.gameObject.AddComponent<ShopItem>().Builder(curItem, price);
            mis.parent = go;

            Image image = mis.GetComponentsInChildren<Image>().Where(image => image.name.ToLower().StartsWith("itemimage")).FirstOrDefault();
            image.sprite = curItem.Sprite;

            TMP_Text text = mis.GetComponentsInChildren<TMP_Text>().Where(text => text.name.ToLower().StartsWith("text")).FirstOrDefault();
            text.text = price.ToString();

        }
        go.GetComponentsInChildren<Image>().Where(image => image.name.ToLower().StartsWith("merchantimage")).FirstOrDefault().sprite = merchantImage;
    }

    private void calcMultiplier()
    {
        multiplier = (int) Math.Ceiling(difficulty / 4.00);
    }
}