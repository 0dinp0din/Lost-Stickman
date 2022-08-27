using UnityEngine;

public class SRC_Chest : MonoBehaviour
{
    public GameObject PFB_Player;
    public GameObject PFB_Sword;
    public GameObject PFB_Armor;
    public GameObject PFB_Helmet;
    
    public bool playerinzone = false;
    public SRC_InteractionBubble thought;
    
    void StuffInChest()
    {
        if (gameObject.name == "Chest_Sword")
        { 
            Instantiate(PFB_Sword, PFB_Player.transform, false);
            Destroy(gameObject);
            thought.GetText("+1 Sharp Sword\n\nI never go anywhere without my trusty sword!");
        } else if (gameObject.name == "Chest_Helmet")
        {
            Instantiate(PFB_Helmet, PFB_Player.transform, false);
            Destroy(gameObject);
            thought.GetText("+1 Rusty Old Helmet\n\nMy old helmet. Heavy as a rock, but has never failed me!");
        }else if (gameObject.name == "Chest_Armor")
        {
            Instantiate(PFB_Armor, PFB_Player.transform, false);
            Destroy(gameObject);
            thought.GetText("+1 Battered Body Armor\n\n My father wore this armor in the battle of the stickmen.");
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerinzone = true;
        
            thought.GetText("(Press 'F' to open the chest)");
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
            StuffInChest();
        }
    }
}
