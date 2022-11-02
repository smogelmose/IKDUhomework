using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    private int superJumpsRemaining;

    // Give your character a name, as a public variable, and print it to the console.
    public string PlayerName = "Indiana Jones";


    //  Define another, but this time a private variable, that will contain a level for your character. Assign the initial value to the level!
    private int PlayerLevel = 100;


    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();

        // Print to the console
        Debug.Log($"Welcome {PlayerName}!");

        // Call method from start() and print the output value.
        PlayerGenerator("Indiana", PlayerLevel);

        int NewPlayerLevel = PlayerGenerator("Indy", PlayerLevel);

        Debug.Log(NewPlayerLevel);
        Debug.Log(PlayerGenerator("Belloq ", PlayerLevel));
    }

    // Generate a method that has the character name and the level as input variables

    /// <summary>
    /// Method for enabling user input for player name and level.
    /// calculations with level variable, and return the value into some output variable.
    /// 
    /// </summary>

    public int PlayerGenerator(string name, int level)
    {
        Debug.LogFormat("Character: {0} - Level: {1}", name, level);

        return level += 10;
    }
    // Update is called once per frame
    void Update()
    {
        // Chack if space key is pressed down
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            jumpKeyWasPressed = true;

        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    // FixedUpdate is called once every physic update
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }
        
        if (jumpKeyWasPressed)
        {
            float jumpPower = 5f;
            if (superJumpsRemaining > 0)
            {
                jumpPower *= 2;
                superJumpsRemaining--;
            }
            rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
    }
}
