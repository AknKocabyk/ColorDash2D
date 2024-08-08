using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;

    private Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow };

    // Şu anki renk indeksini tutar.
    private int currentColorIndex = 0;
    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();

        playerSpriteRenderer.color = colors[currentColorIndex];
    }

    void Update()
    {
        // Q tuşuna basıldığında renk değiştiriyoruz.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Bir sonraki renge geçiyoruz.
            currentColorIndex = (currentColorIndex + 1) % colors.Length;

            // Objenin rengini güncelliyoruz.
            playerSpriteRenderer.color = colors[currentColorIndex];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpriteRenderer otherSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();

        // Eğer çarpışılan obje bir SpriteRenderer içeriyorsa ve rengi objemizin rengiyle aynıysa
        if (otherSpriteRenderer != null && playerSpriteRenderer.color == otherSpriteRenderer.color)
        {
            // Objeyi engelden geçiriyoruz.
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}
