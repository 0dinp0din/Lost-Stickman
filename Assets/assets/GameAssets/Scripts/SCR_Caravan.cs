using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_Caravan : MonoBehaviour
{
    public SCR_Merchant merchant;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && merchant.gameFinished)
        {
            FinishGame();
        }

    }
    
    void FinishGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
