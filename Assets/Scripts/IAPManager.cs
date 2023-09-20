using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine;
using UnityEngine.Purchasing.Extension;

public class IAPManager : MonoBehaviour
{
    [SerializeField] private string _50coinID;
    [SerializeField] private string _100coinID;
    [SerializeField] private string _600coinID;
    [SerializeField] private string _bundleCoinAndLive;

    [SerializeField] private ShopManager shopManager;


    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == _50coinID)
        {
            Debug.Log("You bought 50 coins!");
            shopManager.GetReward(50, 0);
        }
        if(product.definition.id == _100coinID)
        {
            Debug.Log("You bought 100 coins!");
            shopManager.GetReward(100, 0);
        }
        if(product.definition.id == _600coinID)
        {
            Debug.Log("You bought 600 coins!");
            shopManager.GetReward(600, 0);
        }
        if (product.definition.id == _bundleCoinAndLive)
        {
            Debug.Log("You bought 70 coins and unlimited lives for 30m!");
            shopManager.GetReward(600, 30);
        }

    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        Debug.Log(product.definition.id + " failed as a result of " + failureDescription);
    }

}
