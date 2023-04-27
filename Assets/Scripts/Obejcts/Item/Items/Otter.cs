using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otter : Item
{
    public override string ItemName { get; } = "Otter";
    public override Rarity Rarity { get; } = Rarity.mythic;
    public override Target Target { get; } = Target.Player;

    public override void Effect(EnemyStatBlock statBlock)
    {
        throw new System.NotImplementedException();
    }
}
