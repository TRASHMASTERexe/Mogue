using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfoStorage : AdversaryInfoStorage
{
    public EnemyStatBlock statBlock;
    public override AdversaryStatBlock StatBlock { get => statBlock; set => statBlock = (EnemyStatBlock)value; }

    public void OnClick()
    {
        GameManager.GetManager().InitCombat(statBlock, Item, Gold);
        Destroy(parent);
    }
}
