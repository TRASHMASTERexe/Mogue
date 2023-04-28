using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStatBlock : MonoBehaviour
{
    public int Atk { get; set; } = 0;
    public int Def { get; set; } = 0;
    public int Spd { get; set; } = 0;
    public int Hp { get; set; } = 0;
    public int Gold { get; set; } = 0;
}
