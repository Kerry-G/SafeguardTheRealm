﻿using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int maxLevel = 5;
    public int playerLevel = 1;
    public int playerGold = 0;
    public UnityEvent OnLevelUp; //On level Up event
    public UnityEvent OnGoldChange; //On player's gold Changes event
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Gain level
    public void GainLevel(int cost)
    {
        //Check if Player's level is MAX
        if (CheckLevel())
        {
            //Check if Player's gold is enough or not
            if (CheckGold(cost)) //If enough gold, take gold off from Player
            {
                RemoveGold(cost);
                AddOneLevel();
            }
            else
            {
                //TODO
                //An output that shows player's gold is not enough to buy level-up
                Debug.Log("Not enough gold");
            }
        }
        else
        {
            //TODO
            //An output saying player's level is max
            Debug.Log("Player's level has already reached max");
        }          
    }

    //method: check if gold is enough 
    public bool CheckGold(int gold)
    {
        if (playerGold >= gold)
            return true;

        return false;
    }

    //method: Gain gold
    public void GainGold(int gold)
    {
        playerGold += gold;
        OnGoldChange.Invoke();
    }   

    //method: remove gold 
    public void RemoveGold(int gold)
    {
        playerGold -= gold;
        OnGoldChange.Invoke();
    }

    //method: check is player level is max
    public bool CheckLevel()
    {
        if (playerLevel < maxLevel)
            return true;

        return false;
    }

    //method: increase level by 1
    public void AddOneLevel()
    {
        playerLevel++;
        OnLevelUp.Invoke();
    }

    //Getter for Return Player's level
    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    //Getter for Return Player's gold
    public int GetPlayerGold()
    {
        return playerGold;
    }
}