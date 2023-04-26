using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxPrefabManager
{
    public List<PrefabInfo> prefabs;
    public GameObject BoxContainer;
    public List<BoxType> type = new List<BoxType>();

    public BoxPrefabManager(List<PrefabInfo> prefabs)
    {
        this.prefabs = prefabs;
    }

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
}
