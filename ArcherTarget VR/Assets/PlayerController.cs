using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*When the player picks up an object, set that object to the currentObject and that object's rigidbody to currentRB.
    If you do no do this it will not calculate the physics statistics correctly.
    
    CurrentObject has two booleans you need to change. 
    When you pick up an object, change isHeld = true. 
    When you release the button to throw an object, change thrown = true and isHeld = false
    */
    public ObjectInfo currentObject;

    public int score;

    public PlayerController instance;
    public UIController theUI;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    /*When you creat a player, go to every object with either a UIController or ObjectInfo script attached and 
     replace the temp player with the player you create in thePC*/
}
