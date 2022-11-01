using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Give your character a name, as a public variable, and print it to the console.
    public string PlayerName = "Indiana Jones";


    //  Define another, but this time a private variable, that will contain a level for your character. Assign the initial value to the level!
    private int PlayerLevel = 100;
    

    // Start is called before the first frame update
    void Start()
    {
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
        
        return level +=10;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}


















//6. Check the functionality of your program by giving several different values to your variables.