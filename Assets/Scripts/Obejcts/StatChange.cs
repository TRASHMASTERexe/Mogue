using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StatChange
{
    public Stat stat;
    public ChangeType changeType;
    public double changeAmt;

    public StatChange(Stat stat, ChangeType changeType, int changeAmt)
    {
        this.stat = stat;
        this.changeType = changeType;
        this.changeAmt = changeAmt;
    }
}
