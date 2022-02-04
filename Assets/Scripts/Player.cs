using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Lisa

public class Player : MonoBehaviour
{
    // to change animations
    // btw it took a lot of time to connect all animations
    Animator animator;

    // to know which scene the player is in
    public Scene scene;

    // instructions on what to do, or "helo"
    Instructions text;

    // so that the bullets point the right way
    float rotation;

    // to play the jump sound, though it was pretty annoying so i disabled it
    Playonspacebar sound;

    // to show that the chest is open
    Chest chest;

    // bullets
    [SerializeField]
    private GameObject bullet;

    // shooting
    [SerializeField]
    KeyCode shoot;

    // Interacting
    [SerializeField]
    KeyCode talk;
    [SerializeField]
    KeyCode talk2;

    // movement
    [SerializeField]
    KeyCode right;
    [SerializeField]
    KeyCode left;

    // jumping
    [SerializeField]
    KeyCode up;

    // the direction the bullet moves in
    public Vector3 direction;

    // the position of the cursor
    Vector3 worldmouse;

    //movement speed
    float speed = 5;

    // time between shots
    float shootTimer;


    // the players direction for animations, 1 = right, 2 = left
    int directionA;

    // if the player is in the air or not
    bool grounded;

    // health
    public float health = 11;

    // to jump
    Rigidbody2D rb;

    // if the player has the ruby or not
    public bool ruby = false;

    // mostly for animations, but also so that the player can't take damage right after taking damage
    bool dmg = false;
    float dmgTimer;

    // 0 = nothing, 1 = key, 2 = gun
    public int items = 0;

    // 12 at full
    public float xp = 0;

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
        // increasing the timer so that you can shoot
        shootTimer += Time.deltaTime;

        // the position of the cursor in pixel coordinates
        Vector3 mousePos = Input.mousePosition;

        // the cursor's position in uhh not pixel coordinates? i don't remember what they're called
        worldmouse = Camera.main.ScreenToWorldPoint(mousePos);

        // getting the direction to shoot in
        direction = new Vector3(worldmouse.x - transform.position.x, worldmouse.y - transform.position.y, 0).normalized;

        // getting the rotation of the bullet and converting it to degrees
        rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // shooting
        if (Input.GetKey(shoot) && shootTimer > 0.5 && items == 2)
        {
            shootTimer = 0; // so that you can't shoot again until half a second has passed
            Instantiate(bullet, transform.position + direction * 2, Quaternion.Euler(0, 0, rotation)); // spawning the bullet a bit away from the player and in the right direction and rotation
            
            // removing the directions on how to shoot in that scene. They appear when you get your gun
            if (scene.name == "Lisa")
            {
                if (text.instructions != "")
                {
                    text.instructions = "";
                }
            }
        }

        // moving to the right
        if (Input.GetKey(right))
        {
            directionA = 1; // setting the direction
            if (dmg == false) // so that it can play its damage animation
            {
                if (grounded == false) // playing the right jumping animation
                {
                    animator.SetInteger("folium", 4);
                }
                if (grounded == true) // playing the right walking animation
                {
                    animator.SetInteger("folium", 0);
                }
            }

            // because the borders are different in different scenes
            // so i just realised i could have had the border as a float that changed for every scene, so that one of these would be enough, but now they exist already so i'll keep them
            if (transform.position.x < 25.5 && scene.name == "Lisa")
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            if (transform.position.x < 25.5 && scene.name == "Level 1")
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            if (transform.position.x < 40 && scene.name == "Level 2")
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            if (transform.position.x < 40 && scene.name == "Level 2.1")
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            if (transform.position.x < 73.5 && scene.name == "Level 3")
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            if (transform.position.x < 73.5 && scene.name == "Boss Battle")
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
        }
        // moving left
        if (Input.GetKey(left))
        {
            directionA = 2; // setting the direction
            if (dmg == false) // so that it can play its damage animation
            {
                if (grounded == false) // playing the left jumping animation
                {
                    animator.SetInteger("folium", 2);
                }
                if (grounded == true) // playing the left walking animation
                {
                    animator.SetInteger("folium", 1);
                }
            }
            if (transform.position.x > -25.5) // the left border is the same in every scene
            {
                transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            }
        }

        // idle animations
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

        // dying
        if (health <= 0)
        {
            if (dmg == false)
            {
                // reloading the scene when the death animation has played
                SceneManager.LoadScene(scene.name);
            }
            if (dmg == true) // playing the death animation
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
        // so that the xp can't go above 12
        if (xp > 12)
        {
            xp = 12;
        }
        // having the ruby and gun in the scenes below
        if (scene.name == "Level 1" || scene.name == "Level 2" || scene.name == "Level 3" || scene.name == "Level 2.1" || scene.name == "Boss Battle")
        {
            items = 2;
            ruby = true;
        }

        // damage
        if (dmg == true)
        {
            // just timer stuff
            dmgTimer += Time.deltaTime;
            if (dmgTimer >= 1)
            {
                // changing to the idle animations so that it doesn't keep playing the damage animations
                if (directionA == 1)
                {
                    animator.SetInteger("folium", 5);
                }
                if (directionA == 2)
                {
                    animator.SetInteger("folium", 3);
                }

                dmgTimer = 0;
                dmg = false; // being able to take damage and do stuff
            }

            // damage animations for when the player isn't dying
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

        // so that the enemies in level 2 don't push the player out of the border
        if (transform.position.x < -25.5)
        {
            transform.position = new Vector3(-25.4f, -9.8f, 0);
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        // jumping
        if (Input.GetKey(up) && collision.gameObject.tag == "Ground" && dmg == false)
        {
            rb.AddForce(transform.up * 4, ForceMode2D.Impulse);
            sound.someSound.Play();
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        // picking up the key
        if (collision.gameObject.name == "ShroomKey")
        {
            if (Input.GetKey(talk) || Input.GetKey(talk2))
            {
                items = 1; // so that the player has it
                Destroy(collision.gameObject); // well the player has picked it up, so it wouldn't make sense to keep it in the scene
            }
        }

        // opening the chest
        if (collision.gameObject.name == "ShroomChest_Closed" && items == 1) // only if the key has been picked up
        {
            if (Input.GetKey(talk) || Input.GetKey(talk2))
            {
                text.instructions = "Shoot with Leftclick"; // so that the player knows how to shoot
                items = 2; // so that the player has the gun
                Destroy(collision.gameObject); // destroying the closed chest
                chest.transform.position = new Vector3(6.5f, 4, 0); // moving the open chest to its place
            }
        }

        // jumping on platforms
        if (Input.GetKey(up) && collision.gameObject.tag == "SkyGround" && dmg == false)
        {
            rb.AddForce(transform.up * 8, ForceMode2D.Impulse);
            sound.someSound.Play();
        }

        // changing to the dialogue scene
        if (Input.GetKey(talk) || Input.GetKey(talk2))
        {
            if (collision.gameObject.name == "DialogueTrigger1" && items == 2) // if the player has the gun
            {
                SceneManager.LoadScene("Dialogue", LoadSceneMode.Single);
            }
        }

        // changing to level 2
        if (collision.gameObject.name == "Level2Transport" && xp >= 12) // so that you can't proceed unless you've gotten your xp up
        {
            if (Input.GetKey(talk) || Input.GetKey(talk2))
            {
                SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
            }
        }

        // changing to the end dialogue from level 3
        if (collision.gameObject.name == "DialogueTrigger3" && xp >= 12)
        {
            if (Input.GetKey(talk) || Input.GetKey(talk2))
            {
                SceneManager.LoadScene("EndDialogue", LoadSceneMode.Single);
            }
        }

        // transport to level 2
        if (Input.GetKey(talk) || Input.GetKey(talk2))
        {
            if (collision.gameObject.name == "DialogueTrigger2" // && xp >= 12
                )
            {
                SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true; // the player's on the ground

            // idle animations
            if (directionA == 1)
            {
                animator.SetInteger("folium", 5);
            }
            if (directionA == 2)
            {
                animator.SetInteger("folium", 3);
            }
        }

        // taking damage
        if (dmg == false) // so that you can't take damage right after taking damage
        {
            if (collision.gameObject.tag == "Bullet")
            {
                dmg = true;
                health -= 1;
            }
            if (collision.gameObject.tag == "Enemy2")
            {
                dmg = true;
                health -= 2; // they're dangerous
            }
            if (collision.gameObject.tag == "Enemy")
            {
                dmg = true;
                health -= 1;
            }
        }

        if (collision.gameObject.tag == "ramla")
        {
            SceneManager.LoadScene(scene.name);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        // air stuff
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false; // the player's in the air

            // animations
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
        // not showing instructions when the player isn't touching the game objects
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

        // more air stuff, but now they come from platforms
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
        // instructions
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
            text.instructions = "Helo"; // this one isn't an instruction, but it exists anyways because the dude saying it is very polite
        }
        if (collision.gameObject.name == "ShroomKey")
        {
            text.instructions = "F or RightClick to Interact";
        }

        // ground stuff, but for platforms
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
