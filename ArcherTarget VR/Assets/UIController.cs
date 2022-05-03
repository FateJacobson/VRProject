using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text objectText, massText, weightText, forceText, inVelocityText, finVelocityText, scoreText, accelText, timeText;

    public PlayerController thePC;

    // Start is called before the first frame update
    void Start()
    {
        objectText.text = "Object: 0";
        massText.text = "Mass: 0";
        weightText.text = "Weight: 0";
        forceText.text = "Force: 0";
        inVelocityText.text = "Initial Velocity: 0";
        finVelocityText.text = "Final Velocity: 0";
        accelText.text = "Acceleration: 0";
        timeText.text = "Time: 0";
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + thePC.instance.score;
        if (thePC.instance.currentObject != null) {
            objectText.text = "Object: " + thePC.instance.currentObject.objectName;
            massText.text = "Mass: " + thePC.instance.currentObject.theRB.mass;
            weightText.text = "Weight: " + thePC.instance.currentObject.objectWeight;
            if (thePC.instance.currentObject.updateUI)
            {
                inVelocityText.text = "Initial Velocity: " + thePC.instance.currentObject.inVelocity;
                finVelocityText.text = "Final Velocity: " + thePC.instance.currentObject.finVelocity;
                timeText.text = "Time " + thePC.instance.currentObject.totalTime;
                accelText.text = "Acceleration: " + thePC.instance.currentObject.calcAcceleration;
                forceText.text = "Force: " + thePC.instance.currentObject.calcForce;
            }
        }
    }
}
