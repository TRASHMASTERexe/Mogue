using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spikes : Trap
{
    public override int MinDmg { get;} = 1;
    public override int MaxDmg { get;} = 3;
    public override int MinSpd { get;} = 5;
    public override int MaxSpd { get;} = 7;
    public override int MinGold { get;} = 3;
    public override int MaxGold { get;} = 5;
    public override int DifficultyLevel { get;} = 1;
    public override List<Rarity> LootRarities { get; } = new List<Rarity>() { Rarity.common, Rarity.uncommon};
}
