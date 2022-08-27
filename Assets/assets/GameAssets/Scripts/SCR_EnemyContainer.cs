using UnityEngine;

public class SCR_EnemyContainer : MonoBehaviour
{
    public SCR_PerlinNoiseMap map;

    public GameObject PFB_Ghost;
    private int numOfEnemies = 0;

    
    void CreateEnemy(int x, int y)
    {
        int randomCoin = Random.Range(0, 100);
        if (randomCoin == 3)
        {
            numOfEnemies++;
            GameObject ghost = Instantiate(PFB_Ghost, transform);
            ghost.name = string.Format("Ghost number {0}", numOfEnemies);
            ghost.transform.localPosition = new Vector3(x, y, 0);
        }
    }
    
    
    public void GhostSpawner()
    {
        foreach (var r in map.tile_grid)
        {
            foreach (var i in r)
            {
                int tileposX = (int) i.transform.position.x;
                int tileposY = (int) i.transform.position.y;

                if (i.transform.parent.name != "PFB_sea")
                {
                    CreateEnemy(tileposX, tileposY);
                    
                }
            }
        }
    }



}
