using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantInfoStorage : MonoBehaviour
{
    public GameObject parent { get; set; }
    public ShopItem ShopItem { get; set; }

    public void OnClick()
    {
        Debug.Log("inside onclick");
        if (GameManager.GetManager().InitShopInteraction(ShopItem))
        {
            //popup telling what the item does??
            Destroy(parent);
        }
    }

}
