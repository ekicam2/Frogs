using UnityEngine;
using System.Collections;

public class SpawnersManager : MonoBehaviour {

    public GameObject[] spawners;
    public Enemy[] enemies;
    public Enemy[] bosses;

    public uint waves;
    public uint wavesMultipler;
    public float timeTillNextWave;

    private uint currWave   = 0;
    private float deltaTime = 0.0f; 
	
	void Update () {
        deltaTime += Time.deltaTime;
        if(deltaTime >= timeTillNextWave && currWave < waves)
        {
            SpawnEnemies();    
            deltaTime = 0;
        }
	
	}

    void SpawnEnemies()
    {
        if (currWave != waves)
        {

            for (uint i = 0; i < currWave * wavesMultipler; ++i)
            {
                int spawnerIndex = Random.Range(0, spawners.Length);
                int enemyIndex = Random.Range(0, enemies.Length);
                var instance = Instantiate<Enemy>(enemies[enemyIndex]);

                instance.transform.position = new Vector3(spawners[spawnerIndex].transform.position.x
                                                            , 0
                                                            , spawners[spawnerIndex].transform.position.z);
                instance.transform.rotation = spawners[spawnerIndex].transform.rotation;
            }
        }
        else
        {
            if (bosses.Length > 0)
            {
                int spawnerIndex = Random.Range(0, spawners.Length);
                int bossIndex = Random.Range(0, bosses.Length);
                var instance = Instantiate<Enemy>(bosses[bossIndex]);

                instance.transform.position = new Vector3(spawners[spawnerIndex].transform.position.x
                                                            , 0
                                                            , spawners[spawnerIndex].transform.position.z);
                instance.transform.rotation = spawners[spawnerIndex].transform.rotation;
            }
        }

        ++currWave;
    }
}
