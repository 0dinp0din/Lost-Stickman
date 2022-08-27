using UnityEngine;

public class SRC_Ghost : MonoBehaviour
{
    public GameObject player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    
    
}
