using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CharacterMovement : MonoBehaviour
{

    [SerializeField] CharacterController2D controller;
    [SerializeField] int total_money; // added this here bc jerry coins get deleted so cant keep score
    // Start is called before the first frame update
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    Rigidbody2D rb;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject launchPoint;
    [SerializeField] float projectieSpeed = 700f;

    [SerializeField] float delay = 1f;
    float timer = 0;
    // Update is called once per frame

    [SerializeField] int baseHealth = 3;
    int currentHealth;

    [Header("GameEnd")]
    [Space]

    [SerializeField]TextMeshProUGUI YouLose;
    [SerializeField]TextMeshProUGUI YouWin;
    [SerializeField]TextMeshProUGUI Health;
    [SerializeField] Button TryAgainButton;

    void Start()
    {
        currentHealth = baseHealth;
        Health.text = "Lives: " + currentHealth;
        total_money = 0;
        YouLose.enabled = false;
        YouWin.enabled = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        TryAgainButton.gameObject.SetActive(false);
    }
    
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        timer -= Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            

            if (timer < 0)
            {
                //bullet delay
                GameObject bullet = Instantiate(projectile, launchPoint.transform.position, launchPoint.transform.rotation);

                if (controller.isFacingRight())
                    bullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(projectieSpeed + rb.velocity.magnitude, 0));

                else if (!controller.isFacingRight())
                {
                    Vector3 theScale = bullet.transform.localScale;
                    theScale.x *= -1;
                    bullet.transform.localScale = theScale;
                    bullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-projectieSpeed + rb.velocity.magnitude, 0));
                }

                timer = delay;
            }

        }
        if(currentHealth < 0)
        {
            GameOver();
        }else if (total_money >= 16)
        {
            TryAgainButton.gameObject.SetActive(true);
            YouWin.enabled = true;
        }
    }
    void FixedUpdate()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void DealDamage()
    {
        currentHealth--;
        Health.text = "Lives: " + currentHealth;
        print("owie");
        print(currentHealth);
    }

    public void IncrementMoney()
    {
        total_money++;
        print(total_money);
        print("Incremented");
    }

    public int getMoney()
    {
        return total_money;
    }

    void GameOver()
    {
        gameObject.SetActive(false);
        Health.enabled = false;
        YouLose.enabled = true;
        TryAgainButton.gameObject.SetActive(true);
    }
}
