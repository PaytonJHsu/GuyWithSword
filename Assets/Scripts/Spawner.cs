using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject player; // change this to player obj in spawner components inspector
    public int delay = 3;
    float timer;
    public int MinScore = 0;
    public int MaxEnemies = 8; 
    int EnemiesLeft;
    // Start is called before the first frame update
    void Start()
    {
        EnemiesLeft = MaxEnemies;
        timer = 0;
        gameObject.GetComponent<MoveInBorder>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(EnemiesLeft <= 0)
        {
            gameObject.SetActive(false);
        }

        //add conditional here
        if (player.GetComponent<CharacterMovement>().getMoney() >= MinScore)
        {
            gameObject.GetComponent<MoveInBorder>().enabled = true;
            timer -= Time.deltaTime;
            if (timer < 0 && EnemiesLeft > 0)
            {
                GameObject newEnemy = Instantiate(Enemy, transform.position, transform.rotation);
                timer = delay;
                EnemiesLeft--;
            }
        }
       
    }
}
