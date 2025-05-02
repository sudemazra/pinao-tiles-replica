using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tileAction : MonoBehaviour
{
    public SpriteRenderer color;
    public int scoreValue = 1;
    public Rigidbody2D rb;
    public float speed = 500f;

    public AudioClip doSound; // 1. sütun
    public AudioClip miSound; // 2. sütun
    public AudioClip solSound; // 3. sütun
    private AudioSource audioSource;
    private int i = 1;
    private bool isClicked;
    private bool gameEnded;
    public bool IsObstacle = false;
    

    public int columnIndex; // 1: Do, 2: Mi, 3: Sol

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isClicked = false;
    }

    void Update()
    {
        rb.velocity = new Vector2(0, -speed * Time.deltaTime);
        if (FindObjectOfType<score>().scoree > i * 10) // oyun ilerledikçe karolarýn hýzý artsýn
        {
            speed += 100f;
            i++;
        }
    }

    void OnMouseOver() // Hover gibi
    {
        if (Input.GetMouseButtonDown(0) && !gameEnded)
        {
            if (!isClicked) // bir karodan sadece bir kez puan kazanabiliyor olunsun
            {
                if (color.color == Color.white)
                {
                    Debug.Log(speed);
                    color.color = new Color(0.2588f, 0.4824f, 0.3569f);
                    FindObjectOfType<score>().scoreUpdate(scoreValue);
                    PlaySound();
                    isClicked = true;
                } else if (color.color == Color.black) 
                {
                    FindObjectOfType<score>().scoreUpdate(-5);  // -5 puan
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "border")  // Sýnýrla çarpýþma
        {
            if (color.color == Color.white && !gameEnded)  // Beyaz tuþa basýlmýþsa
            {
                gameEnded = true;  // Oyun bitti
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // Finish ekranýna geçiþ
            }
            else if (color.color != Color.white)  // Beyaz tuþa basýlmamýþsa
            {
                // Beyaz tuþa basýlmadýðý için oyun bitmesin
                Debug.Log("Game continues because white button wasn't clicked.");
            }
        }
    }

    private void PlaySound()
    {
        switch (columnIndex)
        {
            case 1: // 1. sütun
                audioSource.PlayOneShot(doSound);
                break;
            case 2: // 2. sütun
                audioSource.PlayOneShot(miSound);
                break;
            case 3: // 3. sütun
                audioSource.PlayOneShot(solSound);
                break;
        }
    }
}
