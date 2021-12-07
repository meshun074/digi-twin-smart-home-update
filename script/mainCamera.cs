
using UnityEngine;

public class mainCamera : MonoBehaviour
{
    private CharacterController camBody;
    private float upDown;
    private float movement;
    private float rotate;
    private Vector3 movementVector;
    private Vector3 upDownVector;
    // Start is called before the first frame update
    void Start()
    {
        camBody = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        upDown = Input.GetAxis("myUpDownControl");
        movement = Input.GetAxis("myVerticalControl");
        rotate = Input.GetAxis("myHorizontalControl");
    }
    private void FixedUpdate()
    {
        movementVector = camBody.transform.forward *movement;
        upDownVector = camBody.transform.up * upDown;
        camBody.transform.Rotate(Vector3.up *rotate * Time.deltaTime*20f);
        camBody.Move(movementVector*Time.deltaTime*2f);
        camBody.Move(upDownVector*Time.deltaTime*2f);


        /*camBody.AddRelativeForce(movementVector, ForceMode.Acceleration);
        Quaternion deltaRotation = Quaternion.Euler(rotationVector * Time.fixedDeltaTime);
        camBody.MoveRotation(camBody.rotation * deltaRotation);
        --for car
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");
        camBody.AddRelativeForce(Vector3.forward * vert * 3f, ForceMode.Acceleration);
        camBody.AddRelativeTorque(Vector3.up * horz * 2f, ForceMode.Acceleration);*/
    }
}

//Inputs 
//up arrow, down arrow,keypad plus,minus keypad,left arrow, right arrow
