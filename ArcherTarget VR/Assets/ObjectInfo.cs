using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    public string objectName;
    public string objectWeight;

    public bool hitTarget, updateUI;

    public Rigidbody theRB;
    public GameObject initPosition;

    //Set this to true when an object is picked up and false as soon is it is thrown. Set thrown to true as soon as it is thrown.
    public bool isHeld, thrown;

    public float calcForce, calcAcceleration, inVelocity, finVelocity, startTime, totalTime;

    public PlayerController thePC;
    public UIController theUI;

    // Start is called before the first frame update
    void Start()
    {
        inVelocity = 0;
        hitTarget = false;
        thrown = false;
        calcAcceleration = 0;
        calcForce = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHeld && thrown)
        {
            //if (inVelocity == 0)
            //{
                inVelocity = theRB.velocity.magnitude;
                theUI.inVelocityText.text = "Initial Velocity: " + inVelocity;
                startTime = Time.time;
            //}
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            hitTarget = true;
            thePC.instance.score++;
            finVelocity = theRB.velocity.magnitude;
            totalTime = Time.time - startTime;
            calcAcceleration = (finVelocity - inVelocity) / totalTime;
            calcForce = theRB.mass * calcAcceleration;
            updateUI = true;
        }
        else if (other.tag == "Ground")
        {
            if (!hitTarget)
            {
                finVelocity = theRB.velocity.magnitude;
                totalTime = Time.time - startTime;
                calcAcceleration = (finVelocity - inVelocity) / totalTime;
                calcForce = theRB.mass * calcAcceleration;
                Debug.Log(calcAcceleration);
                Debug.Log(calcForce);
                Debug.Log("test" + calcAcceleration);
                updateUI = true;
            }

            thrown = false;

            StartCoroutine(delay());
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(3);

        thePC.currentObject.transform.position = initPosition.transform.position;
        thePC.currentObject = null;
    }
}
