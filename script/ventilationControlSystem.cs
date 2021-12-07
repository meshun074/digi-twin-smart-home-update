using UnityEngine;

public class ventilationControlSystem : MonoBehaviour
{
    public GameObject window_1;
    public GameObject window_2;
    public GameObject window_3;
    public GameObject window_4;
    public GameObject window_5;
    public GameObject window_6;
    public GameObject window_7;
    public GameObject venetian_1;
    public GameObject venetian_2;
    public GameObject venetian_3;
    public GameObject roller_1;
    public GameObject roller_2;
    public GameObject rail_1LeftSupport_1;
    public GameObject rail_1LeftSupport_2;
    public GameObject rail_1RightSupport_1;
    public GameObject rail_1RightSupport_2;
    public GameObject rail_2LeftSupport_1;
    public GameObject rail_2LeftSupport_2;
    public GameObject rail_2RightSupport_1;
    public GameObject rail_2RightSupport_2;
    public GameObject rail_3LeftSupport_1;
    public GameObject rail_3LeftSupport_2;
    public GameObject rail_3RightSupport_1;
    public GameObject rail_3RightSupport_2;
    public GameObject rail_4LeftSupport_1;
    public GameObject rail_4LeftSupport_2;
    public GameObject rail_4RightSupport_1;
    public GameObject rail_4RightSupport_2;

    private bool ventOperate=false;
    private bool ventOff= true;
    private bool curtainsOperate = false;
    private bool curtainsOff = true;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //if ventilation is not locked v can operate the ventilation
        if (!securitycontrol.locked)
        {//if v is pressed ventilation operation is set to true which is vent is put off or on
            if (serverControlHub.getClientMessage() == "V"/* Input.GetKeyDown(KeyCode.V)*/)
            {
                serverControlHub.msg = "";
                FindObjectOfType<audioManager>().playSound("windowSound");
                ventOperate = true;
                ventOff = !ventOff;
            }
            if (serverControlHub.getClientMessage() == "C"/* Input.GetKeyDown(KeyCode.C)*/)
            {
                serverControlHub.msg = "";
                FindObjectOfType<audioManager>().playSound("curtainSound");
                venetian_1.GetComponent<AudioSource>().Play();
                venetian_2.GetComponent<AudioSource>().Play();
                curtainsOperate = true;
                curtainsOff = !curtainsOff;
            }
        }
        else
        //else ventilation is locked hence close ventilation.
        {
            ventOperate = true;
            ventOff = true;
            curtainsOperate = true;
            curtainsOff = true;

        }

        //method for opening and closing the window
        operateRightX_AxisWindow(window_1, -37.13179f, -37.64417f, ventOperate);
        operateRightX_AxisWindow(window_2, -35.05714f, -35.63272f, ventOperate);
        operateLeftZ_AxisWindow(window_3, 26.8109f, 26.5149f, ventOperate);
        operateRightZ_AxisWindow(window_4, 26.23812f, 27.23758f, ventOperate);
        operateRightX_AxisWindow(window_5, -44.99136f, -45.59135f, ventOperate);
        operateRightX_AxisWindow(window_6, -46.75993f, -47.40f, ventOperate);
        operateLeftX_AxisWindow(window_7, -36.21936f, -34.76938f, ventOperate);
        //method for opening and closing Venetain frame and roller curtains
        operateVenetainFrame(venetian_1, 0.2f, 1.65f, curtainsOperate);
        operateVenetainFrame(venetian_2, 0.2f, 1.65f, curtainsOperate);
        operateVenetainFrame(venetian_3, 0.2f, 1.65f, curtainsOperate);
        operateVenetainFrame(roller_1, 0.1f, 1.0f, curtainsOperate);
        operateVenetainFrame(roller_2, 0.1f, 1.0f, curtainsOperate);
        //method for opening and closing rail  curtains
        railOpertion(rail_1LeftSupport_1, rail_1LeftSupport_2, rail_1RightSupport_1, rail_1RightSupport_2, -0.0001999998f,
            -0.00533f, -0.01046f, -0.025f, -0.02005f, -0.01559f, curtainsOperate);
        railOpertion(rail_2LeftSupport_1, rail_2LeftSupport_2, rail_2RightSupport_1, rail_2RightSupport_2, -0.0001999998f,
            -0.0051f, -0.0102f, -0.025f, -0.02f, -0.0145f, curtainsOperate);
        railOpertion(rail_3LeftSupport_1, rail_3LeftSupport_2, rail_3RightSupport_1, rail_3RightSupport_2, -0.0001999998f,
            -0.005f, -0.0093f, -0.02229998f, -0.0177f, -0.0128f, curtainsOperate);
        railOpertion(rail_4LeftSupport_1, rail_4LeftSupport_2, rail_4RightSupport_1, rail_4RightSupport_2, -0.0001999998f,
            -0.0053f, -0.01035f, -0.025f, -0.0199f, -0.01532f, curtainsOperate);
           
    }
    //open or close sideways left windows
    void operateLeftZ_AxisWindow(GameObject window, float openLimit, float closeLimit, bool winOperate)
    {
        if (winOperate)
        {
            //if window is closing and it has closed to it limit, then stop operate else keep closing
            if (ventOff)
            {
                if (ventOff && window.transform.position.z <= closeLimit)
                {
                    winOperate = false;
                }
                else
                {
                    window.transform.Translate(Vector3.left * 0.04f);

                }
            }
            else
            {// if window is opening and it has opened to its limit, the stop opening else keep opening
                if (!ventOff && window.transform.position.z >= openLimit)
                {
                    winOperate = false;
                }
                else
                {
                    window.transform.Translate(Vector3.right * 0.04f);

                }
            }
        }
    }

    //open or close sideways right windows
    void operateRightZ_AxisWindow(GameObject window, float openLimit, float closeLimit, bool winOperate)
    {
        if (winOperate)
        {
            if (ventOff)
            {
                if (ventOff && window.transform.position.z >= closeLimit)
                {
                    winOperate = false;
                }
                else
                {
                    window.transform.Translate(Vector3.left * 0.05f);

                }
            }
            else
            {
                if (!ventOff && window.transform.position.z <= openLimit)
                {
                    winOperate = false;
                }
                else
                {
                    window.transform.Translate(Vector3.right * 0.05f);

                }
            }
        }
    }

    //open or close front right windows
    void operateRightX_AxisWindow(GameObject window, float openLimit, float closeLimit, bool winOperate)
    {
        if (winOperate)
        {
            if (ventOff)
            {
                if (ventOff && window.transform.position.x <= closeLimit)
                {
                    winOperate = false;
                }
                else
                {
                    window.transform.Translate(Vector3.left * 0.05f);

                }
            }
            else
            {
                if (!ventOff && window.transform.position.x >= openLimit)
                {
                    winOperate = false;
                }
                else
                {
                    window.transform.Translate(Vector3.right * 0.05f);

                }
            }
        }
    }

    //open or close front left window
    void operateLeftX_AxisWindow(GameObject window, float openLimit, float closeLimit, bool winOperate)
    {
        if (winOperate)
        {
            if (ventOff)
            {
                if (ventOff && window.transform.position.x >= closeLimit)
                {
                    winOperate = false;
                    FindObjectOfType<audioManager>().stopSound("windowSound");
                }
                else
                {
                    window.transform.Translate(Vector3.left * 0.09f);

                }
            }
            else
            {
                if (!ventOff && window.transform.position.x <= openLimit)
                {
                    winOperate = false;
                    FindObjectOfType<audioManager>().stopSound("windowSound");
                }
                else
                {
                    window.transform.Translate(Vector3.right * 0.09f);

                }
            }
        }
    }


    void operateVenetainFrame(GameObject window, float openLimit, float closeLimit, bool frameOperate)
    {
        if (frameOperate)
        {
            //if roller or frsme is closing check its limit and increase scale gradually to close it
            //if limit is reach stop operating
            if (curtainsOff)
            {
                if (curtainsOff && window.transform.localScale.z >= closeLimit)
                {
                    frameOperate = false;
                    FindObjectOfType<audioManager>().stopSound("curtainSound");
                    if(window==venetian_2)
                    {
                        venetian_2.GetComponent<AudioSource>().Stop();
                    }
                    if (window == venetian_1)
                    {
                        venetian_1.GetComponent<AudioSource>().Stop();
                    }
                }
                else
                {
                    window.transform.localScale = new Vector3(1, 1, window.transform.localScale.z + 0.2f * Time.deltaTime); 

                }
            }
            else
            {// if rail is opening and it has opened to its limit, then stop opening else keep opening
                //reduce scale to open frame
                if (!curtainsOff && window.transform.localScale.z <= openLimit)
                {
                    frameOperate = false;
                    FindObjectOfType<audioManager>().stopSound("curtainSound");
                    if (window == venetian_2)
                    {
                        venetian_2.GetComponent<AudioSource>().Stop();
                    }
                    if (window == venetian_1)
                    {
                        venetian_1.GetComponent<AudioSource>().Stop();
                    }
                }
                else
                {
                    window.transform.localScale = new Vector3(1, 1, window.transform.localScale.z - 0.2f * Time.deltaTime);

                }
            }
        }
    }



    void railOpertion(GameObject railLeftSupport_1, GameObject railLeftSupport_2, GameObject railRightSupport_1,
        GameObject railRightSupport_2,float leftRailOpenLimit, float leftRail_1CloseLimit, float leftRail_2CloseLimit,
        float rightRailOpenLimit, float rightRail_1CloseLimit,float rightRail_2CloseLimit, bool railOperate)
    {
        if (railOperate)
        {//if ventilation is closing
            if (curtainsOff)
            {//if rail support close to it limit do nothing else keep closing
                if (curtainsOff && railLeftSupport_1.transform.localPosition.x <= leftRail_1CloseLimit)
                {
                }
                else
                {
                    railLeftSupport_1.transform.Translate(Vector3.left * 0.05f);

                } // the left rail reach it close limit, then stop operating else keep closing and is done for the left rails 
                //as well
                if (curtainsOff && railLeftSupport_2.transform.localPosition.x <= leftRail_2CloseLimit)
                {
                    railOperate = false;
                }
                else
                {
                    railLeftSupport_2.transform.Translate(Vector3.left * 0.05f);
                }

                if (curtainsOff && railRightSupport_1.transform.localPosition.x >= rightRail_1CloseLimit)
                {
                }
                else
                {
                    railRightSupport_1.transform.Translate(Vector3.right * 0.05f);
                }
                if (curtainsOff && railRightSupport_2.transform.localPosition.x >= rightRail_2CloseLimit)
                {
                    railOperate = false;
                }
                else
                {
                    railRightSupport_2.transform.Translate(Vector3.right * 0.05f);
                }
            }
            else
            {//else rail is opening hence check for opening limit as rail opens and do nothing when rail
             //one reach its limits while stop operting when rail two reach its limits
             //do same for the right rails

                if (!curtainsOff && railLeftSupport_1.transform.localPosition.x >= leftRailOpenLimit)
                {
                }
                else
                {
                    railLeftSupport_1.transform.Translate(Vector3.right * 0.05f);
                }
                if (!curtainsOff && railLeftSupport_2.transform.localPosition.x >= leftRailOpenLimit)
                {
                    railOperate = false;
                }
                else
                {
                    railLeftSupport_2.transform.Translate(Vector3.right * 0.05f);
                }
                if (!curtainsOff && railRightSupport_1.transform.localPosition.x <= rightRailOpenLimit)
                {
                }
                else
                {
                    railRightSupport_1.transform.Translate(Vector3.left * 0.05f);
                }
                if (!curtainsOff && railRightSupport_2.transform.localPosition.x <= rightRailOpenLimit)
                {
                    railOperate = false;
                }
                else
                {
                    railRightSupport_2.transform.Translate(Vector3.left * 0.05f);
                }
            }
        }
    }
}
/*
 v - opens and close windows
c- opens and close curtains
 l- locks ventilation by closing ventilation
 */