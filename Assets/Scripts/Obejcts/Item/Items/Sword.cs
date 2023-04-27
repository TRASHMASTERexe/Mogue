using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{

    public override string ItemName { get; } = "Sword";
    public override Rarity Rarity { get; } = Rarity.common;
    public override Target Target { get; } = Target.Player;

    public override void Effect(EnemyStatBlock statBlock)
    {
        throw new System.NotImplementedException();
    }
}
