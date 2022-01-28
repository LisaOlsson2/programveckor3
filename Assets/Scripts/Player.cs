using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Animator animator;

    public Scene scene;

    Instructions text;

    float rotation;

    Playonspacebar sound;

    Chest chest;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    KeyCode shoot;

    [SerializeField]
    KeyCode talk;
    [SerializeField]
    KeyCode talk2;

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

    int directionA;
    // for animations

    bool grounded;
    public float health = 11;
    Rigidbody2D rb;

    public bool ruby = false;
    bool dmg = false;

    public int items = 0;
    // 0 = nothing, 1 = key, 2 = gun

    public float xp = 0;
    // 12 at full

    float dmgTimer;

    // Start is called before the first frame update
    void Start()
    {
        chest = FindObjectOfType<Chest>();
        text = FindObjectOfType<Instructions>();
        animator = GetComponent<Animator>();
        sound = FindObjectOfType<Playonspacebar>();
        rb = GetComponent<Rigidbody2D>();
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        Vector3 mousePos = Input.mousePosition;

        worldmouse = Camera.main.ScreenToWorldPoint(mousePos);

        direction = new Vector3(worldmouse.x - transform.position.x, worldmouse.y - transform.position.y, 0).normalized;

        rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (Input.GetKey(shoot) && shootTimer > 0.5 && items == 2)
        {
            shootTimer = 0;
            Instantiate(bullet, transform.position + direction * 2, Quaternion.Euler(0, 0, rotation));
            if (scene.name == "Lisa")
            {
                if (text.instructions != "")
                {
                    text.instructions = "";
                }
            }
        }

        if (Input.GetKey(right))
        {
            directionA = 1;
            if (dmg == false)
            {
                if (grounded == false)
                {
                    animator.SetInteger("folium", 4);
                }
                if (grounded == true)
                {
                    animator.SetInteger("folium", 0);
                }
            }
            if (transform.position.x < 25.5 && scene.name == "Lisa")
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            if (transform.position.x < 25.5 && scene.name == "Level 1")
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            if (transform.position.x < 25.5 && scene.name == "Level 2")
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            if (transform.position.x < 73.5 && scene.name == "Level 3")
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
        }
        if (Input.GetKey(left))
        {
            directionA = 2;
            if (dmg == false)
            {
                if (grounded == false)
                {
                    animator.SetInteger("folium", 2);
                }
                if (grounded == true)
                {
                    animator.SetInteger("folium", 1);
                }
            }
            if (transform.position.x > -25.5)
            {
                transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            }
        }

        if (Input.GetKey(right) == false && Input.GetKey(left) == false && grounded == true && dmg == false)
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

        if (health <= 0)
        {
            if (dmg == false)
            {
                SceneManager.LoadScene(scene.name);
            }
            if (dmg == true)
            {
                if (directionA == 1)
                {
                    animator.SetInteger("folium", 7);
                }
                if (directionA == 2)
                {
                    animator.SetInteger("folium", 6);
                }
            }
        }
        if (xp > 12)
        {
            xp = 12;
        }
        if (scene.name == "Level 1" || scene.name == "Level 2" || scene.name == "Level 3")
        {
            items = 2;
            ruby = true;
        }
        if (dmg == true)
        {
            dmgTimer += Time.deltaTime;
            if (dmgTimer >= 1)
            {
                dmgTimer = 0;
                dmg = false;
            }
            if (health > 0)
            {
                if (directionA == 1)
                {
                    animator.SetInteger("folium", 8);
                }
                if (directionA == 2)
                {
                    animator.SetInteger("folium", 9);
                }
            }
        }
        if (transform.position.x < -25.5)
        {
            transform.position = new Vector3(-25.4f, -9.8f, 0);
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(up) && collision.gameObject.tag == "Ground" && dmg == false)
        {
            rb.AddForce(transform.up * 4, ForceMode2D.Impulse);
            sound.someSound.Play();
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ShroomKey")
        {
            if (Input.GetKey(talk) || Input.GetKey(talk2))
            {
                items = 1;
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.name == "ShroomChest_Closed" && items == 1)
        {
            if (Input.GetKey(talk) || Input.GetKey(talk2))
            {
                text.instructions = "Shoot with Leftclick";
                items = 2;
                chest.transform.position = new Vector3(6.5f, 4, 0);
                Destroy(collision.gameObject);
            }
        }

        if (Input.GetKey(up) && collision.gameObject.tag == "SkyGround")
        {
            rb.AddForce(transform.up * 8, ForceMode2D.Impulse);
            sound.someSound.Play();
        }
        if (Input.GetKey(talk) || Input.GetKey(talk2))
        {
            if (collision.gameObject.name == "DialogueTrigger1" && items == 2)
            {
                SceneManager.LoadScene("Dialogue", LoadSceneMode.Single);
            }
        }

        if (collision.gameObject.name == "Level2Transport" && xp >= 12)
        {
            if (Input.GetKey(talk) || Input.GetKey(talk2))
            {
                SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
            }
        }
        if (collision.gameObject.name == "DialogueTrigger3" && xp >= 12)
        {
            if (Input.GetKey(talk) || Input.GetKey(talk2))
            {
                SceneManager.LoadScene("EndDialogue", LoadSceneMode.Single);
            }
        }

        if (Input.GetKey(talk) || Input.GetKey(talk2))
        {
            if (collision.gameObject.name == "DialogueTrigger2")
            {
                SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
            }
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
        if (dmg == false)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                dmg = true;
                health -= 1;
            }
            if (collision.gameObject.tag == "Enemy2")
            {
                dmg = true;
                health -= 2;
            }
            if (collision.gameObject.tag == "Enemy")
            {
                dmg = true;
                health -= 1;
            }
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
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ShroomKey")
        {
            text.instructions = "";
        }
        if (collision.gameObject.name == "New Piskel")
        {
            text.instructions = "";
        }
        if (collision.gameObject.name == "ShroomChest_Closed")
        {
            text.instructions = "";
        }
        if (collision.gameObject.name == "DialogueTrigger1")
        {
            text.instructions = "";
        }
        if (collision.gameObject.name == "DialogueTrigger2")
        {
            text.instructions = "";
        }
        if (collision.gameObject.name == "DialogueTrigger3")
        {
            text.instructions = "";
        }
        if (collision.gameObject.name == "Level2Transport")
        {
            text.instructions = "";
        }
        if (collision.gameObject.tag == "SkyGround")
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ShroomChest_Closed" && items == 0)
        {
            text.instructions = "Find a key";
        }
        if (collision.gameObject.name == "DialogueTrigger1" && items != 2)
        {
            text.instructions = "I Can't let you proceed unarmed";
        }
        if (collision.gameObject.name == "Level2Transport" && xp < 12)
        {
            text.instructions = "kill more enemies please";
        }
        if (collision.gameObject.name == "DialogueTrigger2" && xp < 12)
        {
            text.instructions = "kill more enemies";
        }
        if (collision.gameObject.name == "DialogueTrigger3" && xp < 12)
        {
            text.instructions = "kill more enemies";
        }
        if (collision.gameObject.name == "New Piskel")
        {
            text.instructions = "Helo";
        }
        if (collision.gameObject.name == "ShroomKey")
        {
            text.instructions = "F or RightClick to Interact";
        }
        if (collision.gameObject.tag == "SkyGround")
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
    }
}
