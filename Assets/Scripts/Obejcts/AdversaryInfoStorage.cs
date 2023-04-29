using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AdversaryInfoStorage : MonoBehaviour
{
    public abstract AdversaryStatBlock StatBlock { get; set; }
    public Item Item { get; set; }
    public int Gold { get; set; }

    public GameObject parent;
}
