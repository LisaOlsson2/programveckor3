using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    

    Playonspacebar sound;

    [SerializeField]
    private GameObject bullet;


    [SerializeField]
    KeyCode shoot;

    [SerializeField]
    KeyCode talk;

    [SerializeField]
    KeyCode right;

    [SerializeField]
    KeyCode left;

    [SerializeField]
    KeyCode up;

    public Vector3 direction;
    Vector3 worldmouse;
    float speed = 5;
    float shootTimer;

    float health = 10;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        sound = FindObjectOfType<Playonspacebar>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        Vector3 mousePos = Input.mousePosition;

        worldmouse = Camera.main.ScreenToWorldPoint(mousePos);

        direction = new Vector3(worldmouse.x - transform.position.x, worldmouse.y - transform.position.y, 0).normalized;

        if (Input.GetKey(shoot) && shootTimer > 0.5)
        {
            shootTimer = 0;
            Instantiate(bullet, transform.position + direction, Quaternion.identity);
        }

        if (Input.GetKey(right) && transform.position.x < 25.2)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(left) && transform.position.x > -25.2)
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(up) && collision.gameObject.tag == "Ground")
        {
            sound.someSound.Play();
            rb.AddForce(transform.up * 4, ForceMode2D.Impulse);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(talk) && collision.gameObject.name == "DialogueTrigger1")
        {
            SceneManager.LoadScene("Dialogue", LoadSceneMode.Single);
        }

        if (Input.GetKey(talk) && collision.gameObject.name == "DialogueTrigger2")
        {
            SceneManager.LoadScene("Dialogue2", LoadSceneMode.Single);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }
}
