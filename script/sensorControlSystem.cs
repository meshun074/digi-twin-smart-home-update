using System.Collections;
using UnityEngine;

public class sensorControlSystem : MonoBehaviour
{
    #region
    public GameObject smallGateSensor;
    public GameObject mainGateSensor;
    public GameObject door_1Sensor;
    public GameObject door_2Sensor;
    public GameObject door_3Sensor;
    public GameObject door_4Sensor;
    public GameObject door_5Sensor;
    public GameObject door_6Sensor;
    public GameObject door_7Sensor;
    public GameObject door_8Sensor;
    public GameObject door_9Sensor;
    public GameObject door_10Sensor;
    public GameObject door_11Sensor;
    public GameObject door_12Sensor;
    public GameObject door_13Sensor;
    public static bool toggle=true;
    #endregion
    private void OnTriggerEnter(Collider other)
    {
        // if a collider is triggered and is a small gate collider
        //play audio when gate is closed
        if(other.gameObject==smallGateSensor)
        {
            if(securitycontrol.smallGateInstance.transform.localRotation.z <= 0)
            {
                other.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        //if maingate collider is triggered and gate is closed play gate sound
        if (other.gameObject == mainGateSensor)
        {
            if (securitycontrol.gateInstance.transform.position.x <=securitycontrol.closegateLimit)
            {
                toggle = true;
                StartCoroutine(startGateSound(other.gameObject));
            }
        }
        //if door1 collider is triggered activate sensor
        if (other.gameObject == door_1Sensor)
        {
            sensorDoorSystem.door_1SensorActive=true;
        }
        if (other.gameObject == door_2Sensor)
        {
            sensorDoorSystem.door_2SensorActive = true;
        }
        if (other.gameObject == door_3Sensor)
        {
            sensorDoorSystem.door_3SensorActive = true;
        }
        if (other.gameObject == door_4Sensor)
        {
            sensorDoorSystem.door_4SensorActive = true;
        }
        if (other.gameObject == door_5Sensor)
        {
            sensorDoorSystem.door_5SensorActive = true;
        }
        if (other.gameObject == door_6Sensor)
        {
            sensorDoorSystem.door_6SensorActive = true;
        }
        if (other.gameObject == door_7Sensor)
        {
            sensorDoorSystem.door_7SensorActive = true;
        }
        if (other.gameObject == door_8Sensor)
        {
            sensorDoorSystem.door_8SensorActive = true;
        }
        if (other.gameObject == door_9Sensor)
        {
            sensorDoorSystem.door_9SensorActive = true;
        }
        if (other.gameObject == door_10Sensor)
        {
            sensorDoorSystem.door_10SensorActive = true;
        }
        if (other.gameObject == door_11Sensor)
        {
            sensorDoorSystem.door_11SensorActive = true;
        }
        if (other.gameObject == door_12Sensor)
        {
            sensorDoorSystem.door_12SensorActive = true;
        }
        if (other.gameObject == door_13Sensor)
        {
            sensorDoorSystem.door_13SensorActive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //when trigger exit
        if (other.gameObject == smallGateSensor)
        {
            other.gameObject.GetComponent<AudioSource>().Stop();
        }
        if (other.gameObject == mainGateSensor)
        {
            toggle = false;
            StartCoroutine(stopGateSound(other.gameObject));
        }
        if (other.gameObject == door_1Sensor)
        {
            sensorDoorSystem.door_1SensorActive = true;
        }
        if (other.gameObject == door_2Sensor)
        {
            sensorDoorSystem.door_2SensorActive = true;
        }
        if (other.gameObject == door_3Sensor)
        {
            sensorDoorSystem.door_3SensorActive = true;
        }
        if (other.gameObject == door_4Sensor)
        {
            sensorDoorSystem.door_4SensorActive = true;
        }
        if (other.gameObject == door_5Sensor)
        {
            sensorDoorSystem.door_5SensorActive = true;
        }
        if (other.gameObject == door_6Sensor)
        {
            sensorDoorSystem.door_6SensorActive = true;
        }
        if (other.gameObject == door_7Sensor)
        {
            sensorDoorSystem.door_7SensorActive = true;
        }
        if (other.gameObject == door_8Sensor)
        {
            sensorDoorSystem.door_8SensorActive = true;
        }
        if (other.gameObject == door_9Sensor)
        {
            sensorDoorSystem.door_9SensorActive = true;
        }
        if (other.gameObject == door_10Sensor)
        {
            sensorDoorSystem.door_10SensorActive = true;
        }
        if (other.gameObject == door_11Sensor)
        {
            sensorDoorSystem.door_11SensorActive = true;
        }
        if (other.gameObject == door_12Sensor)
        {
            sensorDoorSystem.door_12SensorActive = true;
        }
        if (other.gameObject == door_13Sensor)
        {
            sensorDoorSystem.door_13SensorActive = true;
        }
    }
    IEnumerator  startGateSound(GameObject gameObject)
    {//play sound and wait for 2.8 seconds stop sound and wait again
        while(toggle)
        {
            gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(2.8f);
            gameObject.GetComponent<AudioSource>().Pause();
            yield return new WaitForSeconds(2.8f);
        }
    }
    public static IEnumerator stopGateSound(GameObject gameObject)
    {
            yield return new WaitForSeconds(2f);
            gameObject.GetComponent<AudioSource>().Stop();
        
    }
}
