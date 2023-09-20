using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadSceneCalculator()
    {
        SceneManager.LoadScene("Calculator");
    }
    public void LoadSceneShopIAP()
    {
        SceneManager.LoadScene("ShopIAP");
    }
}
