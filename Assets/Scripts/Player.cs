using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Animator animator;

    float rotation;

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

    int directionA = 1;
    bool grounded;
    float health = 10;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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

        rotation = direction.y/direction.x;

        if (Input.GetKey(shoot) && shootTimer > 0.5)
        {
            print(rotation);
            shootTimer = 0;
            Instantiate(bullet, transform.position + direction * 2, Quaternion.identity);
        }

        if (Input.GetKey(right))
        {
            directionA = 1;
            if (grounded == false)
            {
                animator.SetInteger("folium", 4);
            }
            if (grounded == true)
            {
                animator.SetInteger("folium", 0);
            }
            if (transform.position.x < 25.5)
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
        }
        if (Input.GetKey(left))
        {
            directionA = 2;
            if (grounded == false)
            {
                animator.SetInteger("folium", 2);
            }
            if (grounded == true)
            {
                animator.SetInteger("folium", 1);
            }
            if (transform.position.x > -25.5)
            {
                transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            }
        }

        if (Input.GetKey(right) == false && Input.GetKey(left) == false && grounded == true)
        {
            if (directionA == 1)
            {
                animator.SetInteger("folium", 5);
            }
            if (directionA == 2)
            {
                animator.SetInteger("folium", 3);
            }
        }

        if (Input.GetKey(right) == false && Input.GetKey(left) == false && grounded == true)
        {
            if (directionA == 1)
            {
                animator.SetInteger("folium", 5);
            }
            if (directionA == 2)
            {
                animator.SetInteger("folium", 3);
            }
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(up) && collision.gameObject.tag == "Ground")
        {
            rb.AddForce(transform.up * 4, ForceMode2D.Impulse);
            sound.someSound.Play();
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
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;

            if (directionA == 1)
            {
                animator.SetInteger("folium", 5);
            }
            if (directionA == 2)
            {
                animator.SetInteger("folium", 3);
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
            if (directionA == 1)
            {
                animator.SetInteger("folium", 4);
            }
            if (directionA == 2)
            {
                animator.SetInteger("folium", 2);
            }
        }
    }
}
