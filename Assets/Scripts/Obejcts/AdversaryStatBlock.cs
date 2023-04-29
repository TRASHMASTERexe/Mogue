using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdversaryStatBlock : MonoBehaviour
{
    public Dictionary<Stat, int> StatToValue { get; set; } = new Dictionary<Stat, int>()
    {
        { Stat.Atk , 0 },
        { Stat.Def , 0 },
        { Stat.Spd , 0 },
        { Stat.HP , 0 }
    };
}
