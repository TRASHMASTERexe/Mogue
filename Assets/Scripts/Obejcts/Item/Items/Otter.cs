using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otter : Item
{
    public override string ItemName { get; } = "Otter";
    public override Rarity Rarity { get; } = Rarity.mythic;
    public override Target Target { get; } = Target.Player;
    public override List<StatChange> statChanges { get; } = new()
    {
        new StatChange(Stat.Spd, ChangeType.Divide, 2),
        new StatChange(Stat.Atk, ChangeType.Add, 2),
        new StatChange(Stat.Atk, ChangeType.Add, 2)
    };

    public override void Effect()
    {
        throw new System.NotImplementedException();
    }
}
