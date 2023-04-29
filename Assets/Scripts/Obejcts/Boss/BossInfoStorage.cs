using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossInfoStorage : AdversaryInfoStorage
{
    public BossStatBlock statBlock;
    public override AdversaryStatBlock StatBlock { get => statBlock; set => statBlock = (BossStatBlock) value; }
}
