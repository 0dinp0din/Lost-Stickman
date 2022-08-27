using System;
using TMPro;
using UnityEngine;

public class SCR_Player : MonoBehaviour
{
    public GameObject player;
    private TextMeshPro _textMeshPro;

    private int xpos = 1;
    private int ypos = 1;

    public SCR_PerlinNoiseMap map;
    public SRC_InteractionBubble thought;
    public SCR_Merchant merchant;
    public SRC_Ghost ghost;
    
    void Start()
    {
        player.transform.position = new Vector3(xpos, 3, 1);

    }


    void Update()
    {
        Movement();
    }
    

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (ypos-1 >= 0)
            {
                if (TileChecker(xpos, ypos-1) == false)
                {
                    ypos--;
                }
                
            }
            else
            {
                EdgeOfMap();
            }
            
        } else if (Input.GetKeyDown(KeyCode.W))
        {
            if (ypos+1 < map.map_height)
            {
                if (TileChecker(xpos, ypos+1) == false)
                {
                    ypos++;
                }
                
            }
            else
            {
                EdgeOfMap();
            }
        } else if (Input.GetKeyDown(KeyCode.A))
        {
            if (xpos-1 >= 0)
            {
                if (TileChecker(xpos-1, ypos) == false)
                {
                    xpos--;
                }
                
            }
            else
            {
                EdgeOfMap();
            }
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            if (xpos+1 < map.map_width)
            {
                if (TileChecker(xpos+1, ypos) == false)
                {
                    xpos++;
                }
            }
            else
            {
                EdgeOfMap();
            }
            
        }
        
        player.transform.position = new Vector3(xpos, ypos, 0);
    }

    bool TileChecker(int xval, int yval)
    {
        foreach (var test in map.tile_grid)
        {
            foreach (var i in test)
            {
                if (i.transform.parent.name == "PFB_sea")
                {
                    int tileposX = (int) i.transform.position.x;
                    int tileposY = (int) i.transform.position.y;
                    
                    if (tileposX == (xval) && tileposY == (yval))
                    {
                        thought.GetText("I wish I could swim...");
                        
                        return true;
                    }
                }
            }
        }
        thought.GetText("");
        return false;
    }

    void EdgeOfMap()
    {
        thought.GetText("I can't go that way..");
    }


    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
