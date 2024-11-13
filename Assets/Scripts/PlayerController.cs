using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public float playSpeed;

    public Vector2 spawnPoint;

    public int coins;
    public TextMeshProUGUI coinsText;

    public bool isMoving;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coinsText.text = "Coins: "+coins.ToString();
    }

    // Update is called once per physics call
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //flip the sprite (left or right)
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
           spriteRenderer.flipX = false;
        }

        if (horizontalInput != 0||verticalInput != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        animator.SetBool("isMoving", isMoving);

        rb2d.velocity = new Vector2(horizontalInput * playSpeed, verticalInput * playSpeed);
    }
    // Respawning
    public void Respawn()
    {
        transform.position = spawnPoint;
    }

    public void SetRespawnPoint(Transform checkpointTransform)
    {
        spawnPoint = checkpointTransform.position;
    }

    public void AddCoins(int coinAmount)
    {
        coins += coinAmount;
        coinsText.text = "Coins: "+coins.ToString();
    }

}
