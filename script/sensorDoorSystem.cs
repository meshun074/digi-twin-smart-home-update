using UnityEngine;

public class sensorDoorSystem : MonoBehaviour
{
    public GameObject door_1;
    public GameObject door_1Axis;
    public GameObject door_2;
    public GameObject door_2Axis;
    public GameObject door_3;
    public GameObject door_3Axis;
    public GameObject door_4;
    public GameObject door_4Axis;
    public GameObject door_5;
    public GameObject door_5Axis;
    public GameObject door_6;
    public GameObject door_6Axis;
    public GameObject door_7;
    public GameObject door_7Axis;
    public GameObject door_8;
    public GameObject door_8Axis;
    public GameObject door_9;
    public GameObject door_9Axis;
    public GameObject door_10;
    public GameObject door_10Axis;
    public GameObject door_11;
    public GameObject door_11Axis;
    public GameObject door_12;
    public GameObject door_12Axis;
    public GameObject door_13;
    public GameObject door_13Axis;

    private static bool door_1Operator;
    public static bool door_1SensorActive = false;
    private static GameObject door_1Instance;
    private static GameObject door_1AxisInstance;
    private static float doorRotationSpeed = -80 * 0.055f;
    private static float doorLimit = 0.748f;

    private static bool door_2Operator;
    public static bool door_2SensorActive = false;
    private static GameObject door_2Instance;
    private static GameObject door_2AxisInstance;

    private static bool door_3Operator;
    public static bool door_3SensorActive = false;
    private static GameObject door_3Instance;
    private static GameObject door_3AxisInstance;

    private static bool door_4Operator;
    public static bool door_4SensorActive = false;
    private static GameObject door_4Instance;
    private static GameObject door_4AxisInstance;

    private static bool door_5Operator;
    public static bool door_5SensorActive = false;
    private static GameObject door_5Instance;
    private static GameObject door_5AxisInstance;

    private static bool door_6Operator;
    public static bool door_6SensorActive = false;
    private static GameObject door_6Instance;
    private static GameObject door_6AxisInstance;

    private static bool door_7Operator;
    public static bool door_7SensorActive = false;
    private static GameObject door_7Instance;
    private static GameObject door_7AxisInstance;

    private static bool door_8Operator;
    public static bool door_8SensorActive = false;
    private static GameObject door_8Instance;
    private static GameObject door_8AxisInstance;

    private static bool door_9Operator;
    public static bool door_9SensorActive = false;
    private static GameObject door_9Instance;
    private static GameObject door_9AxisInstance;

    private static bool door_10Operator;
    public static bool door_10SensorActive = false;
    private static GameObject door_10Instance;
    private static GameObject door_10AxisInstance;

    private static bool door_11Operator;
    public static bool door_11SensorActive = false;
    private static GameObject door_11Instance;
    private static GameObject door_11AxisInstance;

    private static bool door_12Operator;
    public static bool door_12SensorActive = false;
    private static GameObject door_12Instance;
    private static GameObject door_12AxisInstance;

    private static bool door_13Operator;
    public static bool door_13SensorActive = false;
    private static GameObject door_13Instance;
    private static GameObject door_13AxisInstance;

    // Start is called before the first frame update
    void Start()
    {
        door_1Instance = door_1;
        door_1AxisInstance = door_1Axis;
        door_2Instance = door_2;
        door_3AxisInstance = door_3Axis;
        door_3Instance = door_3;
        door_2AxisInstance = door_2Axis;
        door_4Instance = door_4;
        door_4AxisInstance = door_4Axis;
        door_5Instance = door_5;
        door_5AxisInstance = door_5Axis;
        door_6Instance = door_6;
        door_6AxisInstance = door_6Axis;
        door_7Instance = door_7;
        door_7AxisInstance = door_7Axis;
        door_8Instance = door_8;
        door_8AxisInstance = door_8Axis;
        door_9Instance = door_9;
        door_9AxisInstance = door_9Axis;
        door_10Instance = door_10;
        door_10AxisInstance = door_10Axis;
        door_11Instance = door_11;
        door_11AxisInstance = door_11Axis;
        door_12Instance = door_12;
        door_12AxisInstance = door_12Axis;
        door_13Instance = door_13;
        door_13AxisInstance = door_13Axis;
    }

    // Update is called once per frame
    void Update()
    {
        operateSensorDoor_1();
        operateSensorDoor_2();
        operateSensorDoor_3();
        operateSensorDoor_4();
        operateSensorDoor_5();
        operateSensorDoor_6();
        operateSensorDoor_7();
        operateSensorDoor_8();
        operateSensorDoor_9();
        operateSensorDoor_10();
        operateSensorDoor_11();
        operateSensorDoor_12();
        operateSensorDoor_13();
    }
    public static void operateSensorDoor_1()
    {
        //if sensor is active
        //operate door
        if (door_1SensorActive)
        {
            door_1SensorActive = false;
            door_1Operator = true;
            if (door_1Instance.transform.localRotation.z <= 0)
            {
                door_1Instance.GetComponent<AudioSource>().Play();
            }

            if (door_1Instance.transform.localRotation.z < 0 && doorRotationSpeed > 0)
            { }
            else if (door_1Instance.transform.localRotation.z > doorLimit && doorRotationSpeed < 0)
            { }
            else
            {
                //change door rotation direction
                doorRotationSpeed = -doorRotationSpeed;
            }
        }


        if (door_1Operator)
        {
            //if door has closed to it limit or  gate has opened to it limit  operating is false

            if (door_1Instance.transform.localRotation.z < 0 && doorRotationSpeed < 0 ||
                door_1Instance.transform.localRotation.z > doorLimit && doorRotationSpeed > 0)
            {
                door_1Operator = false;
                if (door_1Instance.transform.localRotation.z < 0)
                {
                    door_1Instance.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                door_1Instance.GetComponent<Transform>().RotateAround(door_1AxisInstance.transform.position, Vector3.up, doorRotationSpeed);
            }
        }

    }

    public static void operateSensorDoor_2()
    {
        //if sensor is active
        //operate door
        if (door_2SensorActive)
        {
            door_2SensorActive = false;
            door_2Operator = true;
            if (door_2Instance.transform.localRotation.z <= 0)
            {
                door_2Instance.GetComponent<AudioSource>().Play();
            }

            if (door_2Instance.transform.localRotation.z < 0 && doorRotationSpeed > 0)
            { }
            else if (door_2Instance.transform.localRotation.z > doorLimit && doorRotationSpeed < 0)
            { }
            else
            {
                //change door rotation direction
                doorRotationSpeed = -doorRotationSpeed;
            }
           
        }


        if (door_2Operator)
        {
            //if door has closed to it limit or  gate has opened to it limit  operating is false

            if (door_2Instance.transform.localRotation.z < 0 && doorRotationSpeed < 0 ||
                door_2Instance.transform.localRotation.z > doorLimit && doorRotationSpeed > 0)
            {
                door_2Operator = false;
                if (door_2Instance.transform.localRotation.z < 0)
                {
                    door_2Instance.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                door_2Instance.GetComponent<Transform>().RotateAround(door_2AxisInstance.transform.position, Vector3.up, doorRotationSpeed);
            }
        }

    }

    public static void operateSensorDoor_3()
    {
        //if sensor is active
        //operate door
        if (door_3SensorActive)
        {
            door_3SensorActive = false;
            door_3Operator = true;
            if (door_3Instance.transform.localRotation.z <= 0)
            {
                door_3Instance.GetComponent<AudioSource>().Play();
            }
            if (door_3Instance.transform.localRotation.z < 0 && doorRotationSpeed > 0)
            { }
            else if (door_3Instance.transform.localRotation.z > doorLimit && doorRotationSpeed < 0)
            { }
            else
            {
                //change door rotation direction
                doorRotationSpeed = -doorRotationSpeed;
            }
        }


        if (door_3Operator)
        {
            //if door has closed to it limit or  gate has opened to it limit  operating is false

            if (door_3Instance.transform.localRotation.z < 0 && doorRotationSpeed < 0 ||
                door_3Instance.transform.localRotation.z > doorLimit && doorRotationSpeed > 0)
            {
                door_3Operator = false;
                if (door_3Instance.transform.localRotation.z < 0)
                {
                    door_3Instance.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                door_3Instance.GetComponent<Transform>().RotateAround(door_3AxisInstance.transform.position, Vector3.up, doorRotationSpeed);
            }
        }

    }

    public static void operateSensorDoor_4()
    {
        //if sensor is active
        //operate door
        if (door_4SensorActive)
        {
            door_4SensorActive = false;
            door_4Operator = true;
            if (door_4Instance.transform.localRotation.z <= 0)
            {
                door_4Instance.GetComponent<AudioSource>().Play();
            }
            if (door_4Instance.transform.localRotation.z < 0 && doorRotationSpeed > 0)
            { }
            else if (door_4Instance.transform.localRotation.z > doorLimit && doorRotationSpeed < 0)
            { }
            else
            {
                //change door rotation direction
                doorRotationSpeed = -doorRotationSpeed;
            }
        }


        if (door_4Operator)
        {
            //if door has closed to it limit or  gate has opened to it limit  operating is false

            if (door_4Instance.transform.localRotation.z < 0 && doorRotationSpeed < 0 ||
                door_4Instance.transform.localRotation.z > doorLimit && doorRotationSpeed > 0)
            {
                door_4Operator = false;
                if (door_4Instance.transform.localRotation.z < 0)
                {
                    door_4Instance.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                door_4Instance.GetComponent<Transform>().RotateAround(door_4AxisInstance.transform.position, Vector3.up, doorRotationSpeed);
            }
        }

    }

    public static void operateSensorDoor_5()
    {
        //if sensor is active
        //operate door
        if (door_5SensorActive)
        {
            door_5SensorActive = false;
            door_5Operator = true;
            if (door_5Instance.transform.localRotation.z <= 0)
            {
                door_5Instance.GetComponent<AudioSource>().Play();
            }
            if (door_5Instance.transform.localRotation.z < 0 && doorRotationSpeed > 0)
            { }
            else if (door_5Instance.transform.localRotation.z > doorLimit && doorRotationSpeed < 0)
            { }
            else
            {
                //change door rotation direction
                doorRotationSpeed = -doorRotationSpeed;
            }
        }


        if (door_5Operator)
        {
            //if door has closed to it limit or  gate has opened to it limit  operating is false

            if (door_5Instance.transform.localRotation.z < 0 && doorRotationSpeed < 0 ||
                door_5Instance.transform.localRotation.z > doorLimit && doorRotationSpeed > 0)
            {
                door_5Operator = false;
                if (door_5Instance.transform.localRotation.z < 0)
                {
                    door_5Instance.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                door_5Instance.GetComponent<Transform>().RotateAround(door_5AxisInstance.transform.position, Vector3.up, doorRotationSpeed);
            }
        }

    }

    public static void operateSensorDoor_6()
    {
        //if sensor is active
        //operate door
        if (door_6SensorActive)
        {
            door_6SensorActive = false;
            door_6Operator = true;
            if (door_6Instance.transform.localRotation.z <= 0)
            {
                door_6Instance.GetComponent<AudioSource>().Play();
            }
            if (door_6Instance.transform.localRotation.z < 0 && doorRotationSpeed > 0)
            { }
            else if (door_6Instance.transform.localRotation.z > doorLimit && doorRotationSpeed < 0)
            { }
            else
            {
                //change door rotation direction
                doorRotationSpeed = -doorRotationSpeed;
            }
        }


        if (door_6Operator)
        {
            //if door has closed to it limit or  gate has opened to it limit  operating is false

            if (door_6Instance.transform.localRotation.z < 0 && doorRotationSpeed < 0 ||
                door_6Instance.transform.localRotation.z > doorLimit && doorRotationSpeed > 0)
            {
                door_6Operator = false;
                if (door_6Instance.transform.localRotation.z < 0)
                {
                    door_6Instance.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                door_6Instance.GetComponent<Transform>().RotateAround(door_6AxisInstance.transform.position, Vector3.up, doorRotationSpeed);
            }
        }

    }

    public static void operateSensorDoor_7()
    {
        //if sensor is active
        //operate door
        if (door_7SensorActive)
        {
            door_7SensorActive = false;
            door_7Operator = true;
            if (door_7Instance.transform.localRotation.z <= 0)
            {
                door_7Instance.GetComponent<AudioSource>().Play();
            }
            if (door_7Instance.transform.localRotation.z < 0 && doorRotationSpeed > 0)
            { }
            else if (door_7Instance.transform.localRotation.z > doorLimit && doorRotationSpeed < 0)
            { }
            else
            {
                //change door rotation direction
                doorRotationSpeed = -doorRotationSpeed;
            }
        }


        if (door_7Operator)
        {
            //if door has closed to it limit or  gate has opened to it limit  operating is false

            if (door_7Instance.transform.localRotation.z < 0 && doorRotationSpeed < 0 ||
                door_7Instance.transform.localRotation.z > doorLimit && doorRotationSpeed > 0)
            {
                door_7Operator = false;
                if (door_7Instance.transform.localRotation.z < 0)
                {
                    door_7Instance.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                door_7Instance.GetComponent<Transform>().RotateAround(door_7AxisInstance.transform.position, Vector3.up, doorRotationSpeed);
            }
        }

    }

    public static void operateSensorDoor_8()
    {
        //if sensor is active
        //operate door
        if (door_8SensorActive)
        {
            door_8SensorActive = false;
            door_8Operator = true;
            if (door_8Instance.transform.localRotation.z <= 0)
            {
                door_8Instance.GetComponent<AudioSource>().Play();
            }
            if (door_8Instance.transform.localRotation.z < 0 && doorRotationSpeed > 0)
            { }
            else if (door_8Instance.transform.localRotation.z > doorLimit && doorRotationSpeed < 0)
            { }
            else
            {
                //change door rotation direction
                doorRotationSpeed = -doorRotationSpeed;
            }
        }


        if (door_8Operator)
        {
            //if door has closed to it limit or  gate has opened to it limit  operating is false

            if (door_8Instance.transform.localRotation.z < 0 && doorRotationSpeed < 0 ||
                door_8Instance.transform.localRotation.z > doorLimit && doorRotationSpeed > 0)
            {
                door_8Operator = false;
                if (door_8Instance.transform.localRotation.z < 0)
                {
                    door_8Instance.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                door_8Instance.GetComponent<Transform>().RotateAround(door_8AxisInstance.transform.position, Vector3.up, doorRotationSpeed);
            }
        }

    }

    public static void operateSensorDoor_9()
    {
        //if sensor is active
        //operate door
        if (door_9SensorActive)
        {
            door_9SensorActive = false;
            door_9Operator = true;
            if (door_9Instance.transform.localRotation.z <= 0)
            {
                door_9Instance.GetComponent<AudioSource>().Play();
            }
            if (door_9Instance.transform.localRotation.z < 0 && doorRotationSpeed > 0)
            { }
            else if (door_9Instance.transform.localRotation.z > doorLimit && doorRotationSpeed < 0)
            { }
            else
            {
                //change door rotation direction
                doorRotationSpeed = -doorRotationSpeed;
            }
        }


        if (door_9Operator)
        {
            //if door has closed to it limit or  gate has opened to it limit  operating is false

            if (door_9Instance.transform.localRotation.z < 0 && doorRotationSpeed < 0 ||
                door_9Instance.transform.localRotation.z > doorLimit && doorRotationSpeed > 0)
            {
                door_9Operator = false;
                if (door_9Instance.transform.localRotation.z < 0)
                {
                    door_9Instance.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                door_9Instance.GetComponent<Transform>().RotateAround(door_9AxisInstance.transform.position, Vector3.up, doorRotationSpeed);
            }
        }

    }

    public static void operateSensorDoor_10()
    {
        //if sensor is active
        //operate door
        if (door_10SensorActive)
        {
            door_10SensorActive = false;
            door_10Operator = true;
            if (door_10Instance.transform.localRotation.z <= 0)
            {
                door_10Instance.GetComponent<AudioSource>().Play();
            }
            if (door_10Instance.transform.localRotation.z < 0 && doorRotationSpeed > 0)
            { }
            else if (door_10Instance.transform.localRotation.z > doorLimit && doorRotationSpeed < 0)
            { }
            else
            {
                //change door rotation direction
                doorRotationSpeed = -doorRotationSpeed;
            }
        }


        if (door_10Operator)
        {
            //if door has closed to it limit or  gate has opened to it limit  operating is false

            if (door_10Instance.transform.localRotation.z < 0 && doorRotationSpeed < 0 ||
                door_10Instance.transform.localRotation.z > doorLimit && doorRotationSpeed > 0)
            {
                door_10Operator = false;
                if (door_10Instance.transform.localRotation.z < 0)
                {
                    door_10Instance.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                door_10Instance.GetComponent<Transform>().RotateAround(door_10AxisInstance.transform.position, Vector3.up, doorRotationSpeed);
            }
        }

    }

    public static void operateSensorDoor_11()
    {
        //if sensor is active
        //operate door
        if (door_11SensorActive)
        {
            door_11SensorActive = false;
            door_11Operator = true;
            if (door_11Instance.transform.localRotation.z <= 0)
            {
                door_11Instance.GetComponent<AudioSource>().Play();
            }
            if (door_11Instance.transform.localRotation.z < 0 && doorRotationSpeed > 0)
            { }
            else if (door_11Instance.transform.localRotation.z > doorLimit && doorRotationSpeed < 0)
            { }
            else
            {
                //change door rotation direction
                doorRotationSpeed = -doorRotationSpeed;
            }
        }


        if (door_11Operator)
        {
            //if door has closed to it limit or  gate has opened to it limit  operating is false

            if (door_11Instance.transform.localRotation.z < 0 && doorRotationSpeed < 0 ||
                door_11Instance.transform.localRotation.z > doorLimit && doorRotationSpeed > 0)
            {
                door_11Operator = false;
                if (door_11Instance.transform.localRotation.z < 0)
                {
                    door_11Instance.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                door_11Instance.GetComponent<Transform>().RotateAround(door_11AxisInstance.transform.position, Vector3.up, doorRotationSpeed);
            }
        }

    }
    public static void operateSensorDoor_12()
    {
        //if sensor is active
        //operate door
        if (door_12SensorActive)
        {
            door_12SensorActive = false;
            door_12Operator = true;
            if (door_12Instance.transform.localRotation.z <= 0)
            {
                door_12Instance.GetComponent<AudioSource>().Play();
            }
            if (door_12Instance.transform.localRotation.z < 0 && doorRotationSpeed > 0)
            { }
            else if (door_12Instance.transform.localRotation.z > doorLimit && doorRotationSpeed < 0)
            { }
            else
            {
                //change door rotation direction
                doorRotationSpeed = -doorRotationSpeed;
            }
        }


        if (door_12Operator)
        {
            //if door has closed to it limit or  gate has opened to it limit  operating is false

            if (door_12Instance.transform.localRotation.z < 0 && doorRotationSpeed < 0 ||
                door_12Instance.transform.localRotation.z > doorLimit && doorRotationSpeed > 0)
            {
                door_12Operator = false;
                if (door_12Instance.transform.localRotation.z < 0)
                {
                    door_12Instance.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                door_12Instance.GetComponent<Transform>().RotateAround(door_12AxisInstance.transform.position, Vector3.up, doorRotationSpeed);
            }
        }

    }

    public static void operateSensorDoor_13()
    {
        //if sensor is active
        //operate door
        if (door_13SensorActive)
        {
            door_13SensorActive = false;
            door_13Operator = true;
            if (door_13Instance.transform.localRotation.z <= 0)
            {
                door_13Instance.GetComponent<AudioSource>().Play();
            }
            if (door_13Instance.transform.localRotation.z < 0 && doorRotationSpeed > 0)
            { }
            else if (door_13Instance.transform.localRotation.z > doorLimit && doorRotationSpeed < 0)
            { }
            else
            {
                //change door rotation direction
                doorRotationSpeed = -doorRotationSpeed;
            }
        }


        if (door_13Operator)
        {
            //if door has closed to it limit or  gate has opened to it limit  operating is false

            if (door_13Instance.transform.localRotation.z < 0 && doorRotationSpeed < 0 ||
                door_13Instance.transform.localRotation.z > doorLimit && doorRotationSpeed > 0)
            {
                door_13Operator = false;
                if (door_13Instance.transform.localRotation.z < 0)
                {
                    door_13Instance.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                door_13Instance.GetComponent<Transform>().RotateAround(door_13AxisInstance.transform.position, Vector3.up, doorRotationSpeed);
            }
        }

    }

}