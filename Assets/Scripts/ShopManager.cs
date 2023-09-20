using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    [HideInInspector] public float PlayerCoins;
    public int PlayerLives;
    private int prevPlayerLives;
    [HideInInspector] public int hasUnlimitedLives;
    //[HideInInspector] public bool hasRemoveAds;
    private int countDownMinutes = 0;
    private float currentTime = 0.0f;

    [SerializeField] private TMP_Text playerCoinDisplay;
    [SerializeField] private TMP_Text playerHeartDisplay;
    [SerializeField] private GameObject heartInfinity;

    private void Start()
    {
        PlayerCoins = PlayerPrefs.GetFloat("PlayerCoins");

        playerCoinDisplay.text = PlayerCoins.ToString();


        PlayerLives = PlayerPrefs.GetInt("PlayerLives");
        prevPlayerLives = PlayerPrefs.GetInt("PlayerLivesPrev");
        currentTime = PlayerPrefs.GetFloat("TimeRemaining");

        hasUnlimitedLives = PlayerPrefs.GetInt("HasUnlimitedLives");


    }

    private void Update()
    {
        

        if (hasUnlimitedLives == 1)
        {

            if(currentTime > 0)
            {
                Debug.Log("While having u live: " + prevPlayerLives + " " + PlayerLives); 
                PlayerPrefs.SetInt("PlayerLivesPrev", prevPlayerLives);
                PlayerPrefs.SetInt("HasUnlimitedLives", 1);
                PlayerPrefs.SetFloat("TimeRemaining", currentTime);
                playerHeartDisplay.text = (currentTime / 60) + "m";
                heartInfinity.SetActive(true);
                PlayerLives = 9999;
                PlayerPrefs.SetInt("PlayerLives", 9999);
                PlayerPrefs.Save();

                currentTime -= 1 * Time.deltaTime;
            }
            else
            {
                hasUnlimitedLives = 0;
                

            }
            
            
        }

        else
        {

            PlayerLives = PlayerPrefs.GetInt("PlayerLivesPrev");
            playerHeartDisplay.text = PlayerLives.ToString();
            PlayerPrefs.SetInt("PlayerLives", prevPlayerLives);
            PlayerPrefs.Save();
            heartInfinity.SetActive(false);
        }

    }

    public void GetReward(int coinAmounts, int minuteLives)
    {
        PlayerCoins += coinAmounts;
        PlayerPrefs.SetFloat("PlayerCoins", PlayerCoins);
        playerCoinDisplay.text = PlayerCoins.ToString();
        PlayerPrefs.Save();

        
        if(minuteLives > 0) 
        {
            hasUnlimitedLives = 1;
            countDownMinutes +=  minuteLives;
            currentTime = countDownMinutes * 60;
            prevPlayerLives = PlayerLives;
        } 
       
        
    }


  

    



}
