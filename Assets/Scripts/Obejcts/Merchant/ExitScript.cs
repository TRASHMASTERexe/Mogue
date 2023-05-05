using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour
{
    public GameObject parent;
    public AudioClip clip;

    public void OnClick()
    {
        GameManager.GetManager().AddBox();
        Destroy(parent);
    }

}
