using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInBorder : MonoBehaviour
{
    [SerializeField] private float movespeed = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            movespeed *= -1;
        }
    }
}
