using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobMove : MonoBehaviour
{
    public int health = 1;
    public float movespeed = 0.0f;
    public float damage = 1;
    public GameObject coin;

    // Start is called before the first frame update

    void Start()
    {
        int i = Random.Range(0, 2);
        if (i == 1)
            movespeed *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + movespeed * Time.deltaTime, transform.position.y);

        if(health <= 0)
        {

            print("drop");
            GameObject drops = Instantiate(coin, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject col = collision.gameObject;
        if (col.tag == "Border"|| collision.gameObject.tag == "Enemy")
        {
            movespeed *= -1;
        }
        if (col.tag == "Player")
        {
            print("ouchi");
            
            col.GetComponent<CharacterMovement>().DealDamage();

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            health--;
            Destroy(collision.gameObject);
        }
    }


}
