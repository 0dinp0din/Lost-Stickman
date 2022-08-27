using UnityEngine;

public class SCR_CoinContainer : MonoBehaviour
{
    public SCR_PerlinNoiseMap map;

    public GameObject PFB_coins;
    public int numOfCoins = 0;
    
    public int coinsCollected = 0;

    void CreateCoins(int x, int y)
    {
        int randomCoin = Random.Range(0, 100);
        if (randomCoin == 3)
        {
            numOfCoins++;
            GameObject coin = Instantiate(PFB_coins, transform);
            coin.name = string.Format("coin number {0}", numOfCoins);
            coin.transform.localPosition = new Vector3(x, y, 0);
        }
    }
    
    public void CoinTileChecker()
    {
        foreach (var r in map.tile_grid)
        {
            foreach (var i in r)
            {
                int tileposX = (int) i.transform.position.x;
                int tileposY = (int) i.transform.position.y;

                if (i.transform.parent.name != "PFB_sea")
                {
                    CreateCoins(tileposX, tileposY);
                    
                }
            }
        }
    }
    
    public int CoinsLeft()
    {
        int tst = transform.childCount;
        
        return numOfCoins - tst;
    }
}
