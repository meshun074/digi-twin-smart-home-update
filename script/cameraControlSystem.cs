using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControlSystem : MonoBehaviour
{
    public GameObject cameraSystem;
    // all cameras are store
    public GameObject securityCamera_1;
    public GameObject securityCamera_2;
    public GameObject securityCamera_3;
    public GameObject securityCamera_4;
    public GameObject securityCamera_5;
    public GameObject securityCamera_6;
    public GameObject securityCamera_7;
    public GameObject ventCamera_1;
    public GameObject ventCamera_2;
    public GameObject ventCamera_3;
    public GameObject ventCamera_4;
    public GameObject ventCamera_5;
    public GameObject ventCamera_6;
    public GameObject ventCamera_7;
    public GameObject houseviewCamera_1;
    public GameObject houseviewCamera_2;
    public GameObject houseviewCamera_3;
    public GameObject houseviewCamera_4;
    public GameObject houseviewCamera_5;
    public GameObject houseviewCamera_6;
    public GameObject houseviewCamera_7;
    public GameObject houseviewCamera_8;
    public GameObject houseviewCamera_9;

    // security cameras, ventilation cameras and cameras for viewing the are store in different array
    private static GameObject[] securitycameras =new GameObject[7];
    private static GameObject[] ventcameras= new GameObject[7];
    private static GameObject[] houseViewcameras= new GameObject[9];

    // stores the number of view which house view, ventilation and security
    private int viewCounter=2;
    //keeps track of the number of cameras within a view
    private int cameraCounter=0;
    //stores the active came
    private static GameObject currentCamera;
    //at as a contain for setting new camera
    private  GameObject storeCamera;
    // Start is called before the first frame update
    void Start()
    {
        //cameras are stored in an array and passed to their respective views
        GameObject[] securityCam ={securityCamera_1, securityCamera_2,securityCamera_3,
            securityCamera_4, securityCamera_5,securityCamera_6,securityCamera_7};
        GameObject[] ventCam = {ventCamera_1, ventCamera_2, ventCamera_3, ventCamera_4,
           ventCamera_5, ventCamera_6, ventCamera_7 };
        GameObject[] viewCam = { houseviewCamera_1, houseviewCamera_2, houseviewCamera_3, houseviewCamera_4,
            houseviewCamera_5, houseviewCamera_6, houseviewCamera_7, houseviewCamera_8, houseviewCamera_9};
        currentCamera = houseviewCamera_1;
        securitycameras = securityCam;
        ventcameras = ventCam;
        houseViewcameras = viewCam;
    }

    // Update is called once per frame
    void Update()
    {
        if (serverControlHub.getClientMessage() == "K" /*Input.GetKeyDown(KeyCode.K)*/)
        {
            serverControlHub.msg = "";
            cameraSystem.SetActive(!cameraSystem.activeSelf);
        }
        if (cameraSystem.activeSelf)
        { 
        //keypad 8 and 2 moves through views.
        // 8 moves upwards and 2 moves downswards
        // active camera is set to 0 whenever we move to a new view
        if(serverControlHub.getClientMessage()=="8"/* Input.GetKeyDown(KeyCode.Keypad8)*/)
        {
            serverControlHub.msg = "";
            cameraCounter = 0;
            viewCounter++;
            if(viewCounter>2)
            {
                viewCounter = 0;
            }
            //store new actively set camera and passed it to current camera
            storeCamera=setCamera(cameraCounter, viewCounter);
            //disables the previous camera
            currentCamera.SetActive(false);
            currentCamera = storeCamera;//*/
        }
        if (serverControlHub.getClientMessage()=="2"/* Input.GetKeyDown(KeyCode.Keypad2)*/)
        {
            serverControlHub.msg = "";
            cameraCounter = 0;
            viewCounter--;
            if (viewCounter < 0)
            {
                viewCounter = 2;
            }
            storeCamera = setCamera(cameraCounter, viewCounter);
            currentCamera.SetActive(false);
            currentCamera = storeCamera;//*/
        }
        //6 and 4 moves through camera left to right and vice versa respectively
        //view 0 and 1 has the same number of cameras and view with a different number of cameras
        if (serverControlHub.getClientMessage()=="6"/* Input.GetKeyDown(KeyCode.Keypad6) */&& viewCounter==0 || serverControlHub.getClientMessage()=="6"/* Input.GetKeyDown(KeyCode.Keypad6) */&& viewCounter == 1)
        {
            serverControlHub.msg = "";
            cameraCounter++;
            if (cameraCounter > 6)
            {
                cameraCounter = 0;
            }
            storeCamera = setCamera(cameraCounter, viewCounter);
            currentCamera.SetActive(false);
            currentCamera = storeCamera;//*/
        }
        if (serverControlHub.getClientMessage()=="6"/* Input.GetKeyDown(KeyCode.Keypad6)*/ && viewCounter == 2)
        {
            serverControlHub.msg = "";
            cameraCounter++;
            if (cameraCounter > 8)
            {
                cameraCounter = 0;
            }
            storeCamera = setCamera(cameraCounter, viewCounter);
            currentCamera.SetActive(false);
            currentCamera = storeCamera;//*/
        }
        if (serverControlHub.getClientMessage()=="4"/* Input.GetKeyDown(KeyCode.Keypad4)*/ && viewCounter == 0 || serverControlHub.getClientMessage()=="4"/* Input.GetKeyDown(KeyCode.Keypad4)*/ && viewCounter == 1)
        {
            serverControlHub.msg = "";
            cameraCounter--;
            if (cameraCounter < 0)
            {
                cameraCounter = 6;
            }
            storeCamera = setCamera(cameraCounter, viewCounter);
            currentCamera.SetActive(false);
            currentCamera = storeCamera;//*/
        }
        if (serverControlHub.getClientMessage()=="4"/* Input.GetKeyDown(KeyCode.Keypad4)*/ && viewCounter == 2)
        {
            serverControlHub.msg = "";
            cameraCounter--;
            if (cameraCounter < 0)
            {
                cameraCounter = 8;
            }
            storeCamera = setCamera(cameraCounter, viewCounter);
            currentCamera.SetActive(false);
            currentCamera = storeCamera;//*/
        }
        }
    }

    // set camera active depending on the view and the camera number returning the active camera
    GameObject setCamera(int camCount, int viewCount)
    {
        if(viewCount==0)
        {
            securitycameras[camCount].SetActive(true);
            return securitycameras[camCount];
        }
        else if(viewCount==1)
        {
            ventcameras[camCount].SetActive(true);
            return ventcameras[camCount];
        }
        else
        {
            houseViewcameras[camCount].SetActive(true);
            return houseViewcameras[camCount];
        }
    }
}
// inputs
//8,2,4,6