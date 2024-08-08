using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Objenin hareket hızı.
    public float moveSpeed = 5f;

    // Hareket sınırlarını belirlemek için minimum ve maksimum değerler.
    public Vector2 minBounds; // Sol alt köşe
    public Vector2 maxBounds; // Sağ üst köşe

    void FixedUpdate()
    {
        // Sağ-sol hareketi için yatay eksen girdisini alıyoruz.
        float moveHorizontal = Input.GetAxis("Horizontal");
        // Yukarı-aşağı hareketi için dikey eksen girdisini alıyoruz.
        float moveVertical = Input.GetAxis("Vertical");

        // Yeni pozisyonu hesaplıyoruz.
        Vector3 newPosition = transform.position + new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, moveVertical * moveSpeed * Time.deltaTime, 0f);

        // Objenin pozisyonunu sınırlar içinde tutuyoruz.
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        // Objenin pozisyonunu güncelliyoruz.
        transform.position = newPosition;
    }
}
