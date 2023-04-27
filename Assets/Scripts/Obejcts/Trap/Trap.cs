using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    private EnemyStatBlock statBlock;
    
    public Trap(int dmg, int def, int spd)
    {
        this.statBlock = gameObject.AddComponent<EnemyStatBlock>();
        //statBlock.StatBlockConstructor(Target.Enemy, dmg, def, spd);
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
