using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private float playSpeed;

    public Vector2 spawnPoint;

    public int coins;
    public TextMeshProUGUI coinsText;

    public bool isMoving;

    [SerializeField] private int maxHealth;
    public int currentHealth;

    [SerializeField] private Transform healthContainer;
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private Transform canvasTransform;
    [SerializeField] private GameObject gameOverScreenPrefab;

    private GameObject endGameNow;
    [SerializeField] private string levelName;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coinsText.text = "Coins: "+coins.ToString();

        currentHealth = maxHealth;
        UpdateHeart();
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

    public void ResetScene()
    {
        SceneManager.LoadScene(levelName);
    }

    public void UpdateHeart()
    {
        for (int c = 0; c < healthContainer.childCount; c++)
        {
            Destroy(healthContainer.GetChild(c).gameObject);
        }

        for (int i = 0; i < currentHealth; i++)
        {
            Instantiate(heartPrefab, healthContainer);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        UpdateHeart();
        if(currentHealth <= 0)
        {
            endGameNow = Instantiate(gameOverScreenPrefab, canvasTransform);
            endGameNow.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => ResetScene());
        }
        else
        {
            Respawn();
        }
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
