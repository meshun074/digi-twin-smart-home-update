using UnityEngine;

public class lightSystemControl : MonoBehaviour
{
    public GameObject lighteningSystem;
    public GameObject outsideLight;
    public GameObject roomLight;
    public GameObject kitchenToiletLight;
    public GameObject hallLight;
    public GameObject sun;

    private bool lightingSwitchValue=false;
    private bool isDay=true;
    private int timer = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        sun.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer > 1800)
        {
            isDay = !isDay;
            timer = 0;
            if(isDay)
            {
                lighteningSystem.SetActive(false);
            }
            else
            {
                lighteningSystem.SetActive(true);
                outsideLight.SetActive(true);
                //roomLight.SetActive(true);
                //hallLight.SetActive(true);
                //kitchenToiletLight.SetActive(true);
            }
        }
        //if T is pressed and the lighting system is off, then put it on
        if (serverControlHub.getClientMessage() == "T"/* Input.GetKeyDown(KeyCode.T)*/)
        {
            serverControlHub.msg = "";
            if (lighteningSystem.activeSelf==false)
            {
                lighteningSystem.SetActive(true);
            }
        }
        //if O is pressed, all light is turn off or turn on
        if (serverControlHub.getClientMessage() == "O"/* Input.GetKeyDown(KeyCode.O)*/)
        {
            serverControlHub.msg = "";
            lightingSwitchValue = !lightingSwitchValue;
            if (lightingSwitchValue)
            {
                GetComponent<AudioSource>().Play();
            }
            else
            {
                GetComponent<AudioSource>().Stop();
            }
            outsideLight.SetActive(lightingSwitchValue);
            hallLight.SetActive(lightingSwitchValue);
            kitchenToiletLight.SetActive(lightingSwitchValue);
            roomLight.SetActive(lightingSwitchValue);
        }
        //IF R is pressed the outside light is turned off or on
        if (serverControlHub.getClientMessage() == "R"/* Input.GetKeyDown(KeyCode.R)*/)
        {
            serverControlHub.msg = "";
            if (!outsideLight.activeSelf)
            {
                GetComponent<AudioSource>().Play();
            }
            else
            {
                GetComponent<AudioSource>().Stop();
            }
            // Debug.Log(outsideLight.activeSelf);
            outsideLight.SetActive(!outsideLight.activeSelf);
        }
        //if B is pressed the room light is turned off or on
        if (serverControlHub.getClientMessage() == "B"/* Input.GetKeyDown(KeyCode.B)*/)
        {
            serverControlHub.msg = "";
            if (!roomLight.activeSelf)
            {
                GetComponent<AudioSource>().Play();
            }
            else
            {
                GetComponent<AudioSource>().Stop();
            }
            roomLight.SetActive(!roomLight.activeSelf);
        }
        //if G is pressed the kitchen and toilet is turned off or on
        if (serverControlHub.getClientMessage() == "G"/* Input.GetKeyDown(KeyCode.G)*/)
        {
            serverControlHub.msg = "";
            if (!kitchenToiletLight.activeSelf)
            {
                GetComponent<AudioSource>().Play();
            }
            else
            {
                GetComponent<AudioSource>().Stop();
            }
            kitchenToiletLight.SetActive(!kitchenToiletLight.activeSelf);
        }
        //if W is pressed the hall is turned off or on
        if (serverControlHub.getClientMessage() == "W"/* Input.GetKeyDown(KeyCode.W)*/)
        {
            serverControlHub.msg = "";
            if (!hallLight.activeSelf)
            {
                GetComponent<AudioSource>().Play();
            }
            else
            {
                GetComponent<AudioSource>().Stop();
            }
            hallLight.SetActive(!hallLight.activeSelf);
        }
    }
}
//Inputs
//T,O,R,B,G,W