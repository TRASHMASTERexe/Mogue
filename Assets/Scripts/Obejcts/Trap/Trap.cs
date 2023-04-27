using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{

    public Sprite enemyImage;
    public abstract int MinDmg { get; }
    public abstract int MaxDmg { get; }
    public abstract int MinSpd { get; }
    public abstract int MaxSpd { get; }
    public abstract int MinGold { get; }
    public abstract int MaxGold { get; }
    public abstract List<Rarity> lootRarities { get; }
    public abstract int DifficultyLevel { get; }

    public void OnClick()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
