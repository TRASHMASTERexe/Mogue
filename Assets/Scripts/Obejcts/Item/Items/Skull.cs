using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : Item
{
    public override string ItemName { get; } = "Skull";
    public override Rarity Rarity { get; } = Rarity.rare;
    public override Target Target { get; } = Target.Player;
    public override List<StatChange> statChanges { get; } = new()
    {
        new StatChange(Stat.Atk, ChangeType.Multiply, 2),
        new StatChange(Stat.Spd, ChangeType.Subtract, 1)

    };

    public override void Effect()
    {
        
    }
}
