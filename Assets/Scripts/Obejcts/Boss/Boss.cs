using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private EnemyStatBlock statBlock;
    
    public Boss(int dmg, int def, int spd, int hp)
    {
        this.statBlock = gameObject.AddComponent<EnemyStatBlock>();
        statBlock.StatBlockConstructor(Target.Boss, dmg, def, spd, hp, 0);
    }

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
