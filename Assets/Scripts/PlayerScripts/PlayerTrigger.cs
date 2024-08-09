using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerTrigger : MonoBehaviour
{
    // Karakterin SpriteRenderer bileşeni.
    private SpriteRenderer spriteRenderer;

    // Kullanılacak renkler.
    private Color[] colors = { Color.red, Color.green, Color.blue};

    // Şu anki renk indeksini tutar.
    private int currentColorIndex = 0;

    [SerializeField] Image timerImage;
    [SerializeField] float time = 100;

    void Start()
    {
        // Karakterin SpriteRenderer bileşenini alıyoruz.
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Başlangıç rengi olarak ilk rengi ayarlıyoruz.
        spriteRenderer.color = colors[currentColorIndex];
    }

    void Update()
    {
        // Q tuşuna basıldığında renk değiştiriyoruz.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Bir sonraki renge geçiyoruz.
            currentColorIndex = (currentColorIndex + 1) % colors.Length;

            // Karakterin rengini güncelliyoruz.
            spriteRenderer.color = colors[currentColorIndex];
        }

        time -= Time.deltaTime;
        float fillpercent = time / 3;
        timerImage.fillAmount = fillpercent;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        SpriteRenderer otherSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
        print(otherSpriteRenderer.color);
        // Eğer çarpışılan obje bir SpriteRenderer içeriyorsa ve rengi karakterin rengiyle aynıysa
        if (otherSpriteRenderer != null && spriteRenderer.color == otherSpriteRenderer.color)
        {
            // Çarpışmayı yok sayıyoruz, böylece karakter engelden geçebiliyor.
            //Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
            otherSpriteRenderer.color = Color.white;


        }
    }

}
