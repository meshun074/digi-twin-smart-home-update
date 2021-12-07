using UnityEngine;

public class securitycontrol : MonoBehaviour
{
   
    public GameObject gate;
    public GameObject gateSensor;
    public GameObject smallGate;
    public GameObject smallGateSensor;
    public GameObject smallGateAxis;
    public GameObject mainDoor;
    public GameObject mainDoorAxis;
    public GameObject mainDoorSensorObject;
    public GameObject baconyDoor;
    public GameObject baconyDoorAxis;
    public GameObject baconyDoorSensorObject;

    public static bool locked=false;
    public static bool mainDoorSensor = false;
    public static bool baconyDoorSensor = false;
    public static GameObject mainDoorInstance;
    public static GameObject mainDoorAxisInstance;
    public static GameObject smallGateInstance;
    public static GameObject gateInstance;
    public static GameObject baconyDoorInstance;
    public static GameObject baconyDoorAxisInstance;

    private float gateRotationSpeed; 
    private static float doorRotationSpeed;
    private static float baconyDoorRotationSpeed;
    private bool smallgateoperator=false;
    private static bool mainDoorOperator = false;
    private static bool baconyDoorOperator = false;
    private float smallGateLimit = 0.0001193285f;
    private static float mainDoorLimit = 0.35f;
    private static float baconyDoorLimit = 0.5f;

    private bool closeGate = false;
    private bool openGate=false;
    private bool gateswitch=false;
    private float opengateLimit = -35.0f;
    public static float closegateLimit = -41.21014f;

    
    // Start is called before the first frame update
    void Start()
    {
        mainDoorInstance = mainDoor;
        mainDoorAxisInstance = mainDoorAxis;
        smallGateInstance = smallGate;
        gateInstance = gate;
        baconyDoorInstance = baconyDoor;
        baconyDoorAxisInstance = baconyDoorAxis;
        gateRotationSpeed = -100 * Time.deltaTime;
        doorRotationSpeed = -100 * Time.deltaTime;
        baconyDoorRotationSpeed = -80 * 0.055f;
    }

    // Update is called once per frame
    void Update()
    {
        // If L is pressed lock security or unlock security
        if(serverControlHub.getClientMessage() == "L"/*Input.GetKeyDown(KeyCode.L)*/)
        {
            serverControlHub.msg = "";
            locked = !locked;
            FindObjectOfType<audioManager>().playSound("securityLock");
        }
        if(!locked)
        {
            //Enable sensors
            mainDoorSensorObject.GetComponent<CapsuleCollider>().enabled = true;
            baconyDoorSensorObject.GetComponent<CapsuleCollider>().enabled = true;

            mainGateControl();
            smallGateControl();
            mainDoorControl();
            baconyDoorControl();
        }
        else
        {
            LockSecurity();
        }
          
    }

   

    //main gate control
    void mainGateControl()
    {
        //if key m is down switch the gate operation
        if (serverControlHub.getClientMessage() == "M"/*Input.GetKeyDown(KeyCode.M)*/)
        {
            gateInstance.GetComponent<AudioSource>().Play();
            sensorControlSystem.toggle = false;
            StartCoroutine(sensorControlSystem.stopGateSound(gateSensor));
            gateswitch = !gateswitch;
        }
        //if m is pressed and switch to open or true 
        if (serverControlHub.getClientMessage() == "M"/*Input.GetKeyDown(KeyCode.M)*/ && gateswitch == true)
        {
            serverControlHub.msg = "";
            openGate = true;
            closeGate = false;
            //if gate has been opened till it limit, cant open gate again
            if (gateInstance.transform.position.x >= opengateLimit)
            {
                openGate = false;
            }
        }
        //if m is pressed and switch to close or false 
        else if (serverControlHub.getClientMessage() == "M"/*Input.GetKeyDown(KeyCode.M)*/ && gateswitch == false)
        {
            serverControlHub.msg = "";
            closeGate = true;
            openGate = false;
            //if gate has been closed till it limit, cant close gate again
            if (gateInstance.transform.position.x <= closegateLimit)
            {
                closeGate = false;
            }
        }
        //open gate multiplying the time it took to process a previous frame by the x position
        if (openGate)
        {
            //if gate have been open to it limit
            if (gateInstance.transform.position.x >= opengateLimit)
            {
                openGate = false;
                gateInstance.GetComponent<AudioSource>().Stop();
                Debug.Log(gateInstance.transform.position.x + " >= "+ opengateLimit);

            }
            //open gate
            else
            {
                gateInstance.GetComponent<Transform>().Translate(Vector3.right * Time.deltaTime);
            }
        }
        //close gate
        if (closeGate)
        {
            //if gate have been closed to it limit
            if (gateInstance.transform.position.x <= closegateLimit)
            {
                closeGate = false;
                gateInstance.GetComponent<AudioSource>().Stop();
            }
            //close gate
            else
            {
                gateInstance.GetComponent<Transform>().Translate(Vector3.left * Time.deltaTime);
            }
        }
        // for gate position 
        // Debug.Log(gate.transform.position.x);
    }


    //small gate control
    private void smallGateControl()
    {
        //if key s is down
        //operate small gate
        if (serverControlHub.getClientMessage() == "S"/*Input.GetKeyDown(KeyCode.S)*/)
        {
            serverControlHub.msg = "";
            //Debug.Log(smallGate.transform.rotation.z);
            smallgateoperator = true;
            smallGate.GetComponent<AudioSource>().Play();
            smallGateSensor.GetComponent<AudioSource>().Stop();

            if (smallGate.transform.rotation.z < 0 && gateRotationSpeed > 0)
            { }
            else if (smallGate.transform.rotation.z > smallGateLimit && gateRotationSpeed < 0)
            { }
            else
            {
                //change gate rotation direction
                gateRotationSpeed = -gateRotationSpeed;
            }
        }

        if (smallgateoperator)
        {
            //if gate has closed to it limit or  gate has opened to it limit  operating is false

            if (smallGate.transform.rotation.z < 0 && gateRotationSpeed < 0 ||
                smallGate.transform.rotation.z > smallGateLimit && gateRotationSpeed > 0)
            {
                smallgateoperator = false;
                smallGate.GetComponent<AudioSource>().Stop();
                // Debug.Log("cant open");
            }
            // else operate gate
            else
            {
                smallGate.GetComponent<Transform>().RotateAround(smallGateAxis.transform.position, Vector3.up, gateRotationSpeed);
            }
        }

    }

    // lock secrity
    private void LockSecurity()
    {
        closeGate = true;
        smallgateoperator = true;
        mainDoorOperator = true;
        baconyDoorOperator = true;
        //Disable sensors and sensor activators
        mainDoorSensorObject.GetComponent<CapsuleCollider>().enabled = false;
        baconyDoorSensorObject.GetComponent<CapsuleCollider>().enabled = false;

        //close main gate
        if (closeGate)
        {
            //if gate have been closed to it limit
            if (gate.transform.position.x <= closegateLimit)
            {
                closeGate = false;
            }
            //close gate
            else
            {
                gate.GetComponent<Transform>().Translate(Vector3.left * Time.deltaTime);
            }
        }

        if (smallgateoperator)
        {
            //if gate has closed to it limit 

            if (smallGate.transform.rotation.z < 0)
            {
                smallgateoperator = false;
               // Debug.Log("gate is closed");
            }
            // else operate gate by closing it
            else
            {
                smallGate.GetComponent<Transform>().RotateAround(smallGateAxis.transform.position, Vector3.up, -20 * Time.deltaTime);
               // Debug.Log("closing gate");
            }
        }

        if (mainDoorOperator)
        {
            //if door has closed to it limit 

            if (mainDoor.transform.rotation.z < 0)
            {
                mainDoorOperator = false;
                // Debug.Log("door is closed");
            }
            // else operate gate
            else
            {   //Debug.Log(closing door);
                mainDoor.GetComponent<Transform>().RotateAround(mainDoorAxis.transform.position,
                    Vector3.up, -20 * Time.deltaTime);               
            }
        }

        if (baconyDoorOperator)
        {
            //if bacony door has closed to it limit 

            if (baconyDoorInstance.transform.rotation.z < 0 )
            {
                baconyDoorOperator = false;
            }
            // else operate gate
            else
            {
                baconyDoorInstance.GetComponent<Transform>().RotateAround(baconyDoorAxisInstance.transform.position,
                    Vector3.up, -20 * Time.deltaTime);
                //Debug.Log(baconyDoor.transform.rotation.z);
            }
        }
    }

    //main door control
    public static void mainDoorControl()
    {
        //if key D is down
        //operate small gate
        if (serverControlHub.getClientMessage() == "D"/*Input.GetKeyDown(KeyCode.D) */|| mainDoorSensor)
        {
            serverControlHub.msg = "";
            mainDoorSensor = false;
            mainDoorOperator = true;

            if (mainDoorInstance.transform.rotation.z < 0 && doorRotationSpeed > 0)
            { }
            else if (mainDoorInstance.transform.rotation.z > mainDoorLimit && doorRotationSpeed < 0)
                { }
            else
            {
                //change Main dooe rotation direction
                doorRotationSpeed = -doorRotationSpeed;
            }
            //play sound when opening
            if (doorRotationSpeed>0)
            {
                mainDoorInstance.GetComponent<AudioSource>().Play();
            }
        }
        if (mainDoorOperator)
        {
            //if door has closed to it limit or  door has opened to it limit  operating is false

            if (mainDoorInstance.transform.rotation.z < 0 && doorRotationSpeed < 0 ||
                mainDoorInstance.transform.rotation.z > mainDoorLimit && doorRotationSpeed > 0)
            {
                mainDoorOperator = false;
                if (doorRotationSpeed < 0)
                {
                    mainDoorInstance.GetComponent<AudioSource>().Play();
                }
                // Debug.Log("cant open");
            }
            // else operate gate
            else
            {
                mainDoorInstance.GetComponent<Transform>().RotateAround(mainDoorAxisInstance.transform.position, Vector3.up, doorRotationSpeed);
                //Debug.Log(mainDoor.transform.rotation.z);
            }
        }
    }

    // bacony door control
    public static void baconyDoorControl()
    {
        //if key Q is down
        //operate bacony door
        if (serverControlHub.getClientMessage() == "Q"/* Input.GetKeyDown(KeyCode.Q)*/ || baconyDoorSensor)
        {
            serverControlHub.msg = "";
            baconyDoorSensor = false;
            baconyDoorOperator = true;
            if (baconyDoorInstance.transform.rotation.z < 0 && baconyDoorRotationSpeed > 0 )
            { }
            else if(baconyDoorInstance.transform.rotation.z > baconyDoorLimit && baconyDoorRotationSpeed < 0)
            { }
            else {
                //change bacony door rotation direction
                baconyDoorRotationSpeed = -baconyDoorRotationSpeed;
            }
            if (baconyDoorRotationSpeed > 0)
            {
                baconyDoorInstance.GetComponent<AudioSource>().Play();
            }
        }

        if (baconyDoorOperator)
        {
            //if bacony door has closed to it limit or  bacony door has opened to it limit  operating is false

            if (baconyDoorInstance.transform.rotation.z < 0 && baconyDoorRotationSpeed < 0 ||
                baconyDoorInstance.transform.rotation.z > baconyDoorLimit && baconyDoorRotationSpeed > 0)
            {
                baconyDoorOperator = false;
                if (baconyDoorRotationSpeed < 0)
                {
                    baconyDoorInstance.GetComponent<AudioSource>().Play();
                }
            }
            // else operate gate
            else
            {
                baconyDoorInstance.GetComponent<Transform>().RotateAround(baconyDoorAxisInstance.transform.position, Vector3.up, baconyDoorRotationSpeed);
                //Debug.Log(baconyDoor.transform.rotation.z);
            }
        }
    }


}



/* Q- Bacony door
 * L- Locked all doors and gates
 * S- Small gate
 * M- Main gate
 * D- Main door
 */





