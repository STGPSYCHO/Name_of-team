using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public Player player;
    public float destroyDelay = 1f;
    public GameObject enemy;
    private List<GameObject> Enemies;
    public int enemiesCount;
    private int enemyCnt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivateModule()
    {
        ToCountEnemies();
    }
    private void ToCountEnemies()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList<GameObject>();
        enemyCnt = Enemies.Count();
        while (enemyCnt <= enemiesCount) 
        {
            Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0 );
            GameObject go = Instantiate(enemy, player.transform.position + position, player.transform.rotation);
            go.SetActive(true);
            enemyCnt++;
        }
    }
}
