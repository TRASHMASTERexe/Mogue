using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{

    public override string ItemName { get; } = "Sword";
    public override Rarity Rarity { get; } = Rarity.common;
    public override Target Target { get; } = Target.Player;
    public override List<StatChange> statChanges { get; } = new()
    {
        new StatChange(Stat.Atk, ChangeType.Add, 1)
    };

    public override void Effect()
    {

    }
}
