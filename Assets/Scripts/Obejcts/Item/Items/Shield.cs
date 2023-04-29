using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Item
{
    public override string ItemName { get; } = "Shield";
    public override Rarity Rarity { get; } = Rarity.uncommon;
    public override Target Target { get; } = Target.Player;
    public override List<StatChange> statChanges { get; } = new()
    {
        new StatChange(Stat.Def, ChangeType.Add, 2)
    };

    public override void Effect()
    {
        throw new System.NotImplementedException();
    }
}
