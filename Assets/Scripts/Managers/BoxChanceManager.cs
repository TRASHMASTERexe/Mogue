using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxChanceManager : MonoBehaviour
{
    public List<PrefabInfo> prefabs = new List<PrefabInfo>();

    public BoxType getRandomPrefab()
    {
        
        List<PrefabInfo> success = new List<PrefabInfo>();
        prefabs.ForEach(prefab =>
        {
            int roll = UnityEngine.Random.Range(1, 100);
            if(prefab.chance >= roll)
            {
                success.Add(prefab);
            }
        });

        if (success.Count > 0)
        {
            List<PrefabInfo> HighestPrio = success.OrderBy(p => p.priority).GroupBy(p => p.priority).First().ToList();
            if(HighestPrio.Count > 1)
            {
                return HighestPrio[UnityEngine.Random.Range(0, HighestPrio.Count - 1)].boxType;
            }
            else
            {
                return HighestPrio.First().boxType;
            }
        }
        else
        {
            return BoxType.Enemy;
        }
    }

    private void Awake()
    {
        prefabs.Add(new PrefabInfo(BoxType.Merchant, 20, 3, 50));
        prefabs.Add(new PrefabInfo(BoxType.Trap, 20, 3, 50));
        prefabs.Add(new PrefabInfo(BoxType.Boss, 0, 1, 100));
    }
}
