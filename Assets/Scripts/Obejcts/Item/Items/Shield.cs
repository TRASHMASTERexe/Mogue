using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Item
{
    public override string ItemName { get; } = "Shield";
    public override Rarity Rarity { get; } = Rarity.uncommon;
    public override Target Target { get; } = Target.Player;

    public override void Effect(EnemyStatBlock statBlock)
    {
        throw new System.NotImplementedException();
    }
}
