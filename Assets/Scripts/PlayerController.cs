using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float playSpeed;

    public Vector2 spawnPoint;

    public int coins;
    public TextMeshProUGUI coinsText;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coinsText.text = "Coins: "+coins.ToString();
    }

    // Update is called once per physics call
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

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
