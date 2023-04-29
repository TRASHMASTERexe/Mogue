using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapInfoStorage : AdversaryInfoStorage
{
    public TrapStatBlock statBlock;
    public override AdversaryStatBlock StatBlock { get => statBlock; set => statBlock = (TrapStatBlock)value; }
}
