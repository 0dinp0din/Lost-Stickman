using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class SCR_Merchant : MonoBehaviour
{
    private bool playerinzone = false;
    private bool happenonce = false;
    public bool gameFinished = false;
    public SRC_InteractionBubble thought;
    public SCR_CoinContainer coins;
    public SCR_EnemyContainer enemies;
    public SCR_CoinContainer coinContainer;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        {
            playerinzone = true;
        
            thought.GetText("(Press 'F' to talk to the stranger)");
        }
    }
    
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerinzone = false;
            Debug.Log("byebye");
            thought.GetText("");
        }
    }


    private void Update()
    {
        if (playerinzone && Input.GetKeyDown(KeyCode.F))
        {

            if (happenonce == false)
            {
                thought.GetText("Lost trader: Hello there! This forest is haunted by ghosts.\nThe ghosts stole all my coins!\n" +
                                "If you can help me find them, i will give you a ride home.");
                happenonce = true;
                coins.CoinTileChecker();
                enemies.GhostSpawner();
            } else if (happenonce && coinContainer.transform.childCount > 0)
            {
                thought.GetText("Lost trader: You have found " + coinContainer.CoinsLeft() + " out of " + coinContainer.numOfCoins + " coins.");
            }
            else if (happenonce && coinContainer.transform.childCount <= 0)
            {
                gameFinished = true;
                thought.GetText("Lost trader: I'm glad to see you still in one piece! Thank you for collecting my coins.\n" +
                                "As promised, I will give you a ride home. Just jump into the caravan when you're ready!");
            }
        }
    }
    
}
