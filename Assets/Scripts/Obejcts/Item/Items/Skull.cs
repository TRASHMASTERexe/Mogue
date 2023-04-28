using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : Item
{
    public override string ItemName { get; } = "Skull";
    public override Rarity Rarity { get; } = Rarity.rare;
    public override Target Target { get; } = Target.Player;

    public override void Effect()
    {
        throw new System.NotImplementedException();
    }
}
