using System.Linq;  
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{

    //public List<EnemyInfo> prefabs;
    public GameObject ItemStorage;
    private Dictionary<Rarity, List<Item>> difficultyToListPrefabs = new();
    private Dictionary<Rarity, int> RarityToChance = new Dictionary<Rarity, int>()
    {
        {Rarity.uncommon, 750},
        {Rarity.rare, 950 },
        {Rarity.mythic, 1000}
    };

    public Item rollItem()
    {

        int roll = Random.Range(1, 1001);
        int u = RarityToChance.GetValueOrDefault(Rarity.uncommon);
        int r = RarityToChance.GetValueOrDefault(Rarity.rare);
        int m = RarityToChance.GetValueOrDefault(Rarity.mythic);

        List<Item> items = null;

        if (roll >= m)
        {
            items = difficultyToListPrefabs.GetValueOrDefault(Rarity.mythic);
        }
        else if (roll >= r)
        {
            items = difficultyToListPrefabs.GetValueOrDefault(Rarity.rare);
        }
        else if (roll >= u)
        {
            items = difficultyToListPrefabs.GetValueOrDefault(Rarity.uncommon);
        }
        else
        {
            items = difficultyToListPrefabs.GetValueOrDefault(Rarity.common);
        }

        return items[Random.Range(0, items.Count - 1)];
    }

    public List<Item> rollItems(int numItems)
    {
        List<Item> items = new List<Item>();
        for(int i = 0; i< numItems; i++)
        {
            items.Add(rollItem());
        }
        return items;
    }

    private void Awake()
    {
        ItemStorage.GetComponents<Item>().ToList().ForEach(item =>
        {
            Rarity rarity = item.Rarity;
            if(difficultyToListPrefabs.ContainsKey(rarity))
            {
                difficultyToListPrefabs.GetValueOrDefault(rarity).Add(item);
            }
            else
            {
                difficultyToListPrefabs.Add(rarity, new List<Item>() {item});
            }
        });
    }
}
