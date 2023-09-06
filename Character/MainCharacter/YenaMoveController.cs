using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using UnityEngine.InputSystem;
using DG.Tweening;

public class YenaMoveController : MonoBehaviour
{
    private Transform trans;
    // drag in component
    public YenaDataBiding yenaDataBiding;
    private CharacterController characterController;
    public JoystickControl leftJS;
    public Transform model;
    public YenaAttributeControl yenaAttributeControl;
    // m_variables
    MyInput myInput;
    // movement vars
    private Vector3 tempVector3d = new Vector3();
    private Vector3 moveVector3D;
    public Vector2 moveVector2D;
    Vector3 characterFoward;
    Quaternion q;
    // character parameters
    public float rotSpeed = 0.05f;
    //gravity var
    float gravity = -9.8f;
    float groundedGravity = -0.5f;
    public float smoothfactor = 5;
    //ease
    public float delay_smooth = 0.2f;
    Vector2 oldJSInput;
    Vector2 oldKeyboardInput;
    bool takingKeyboardInput;
    bool takingJsInput;
    Vector2 inputMovementVector;
    private void Awake()
    {
        //ease
        oldJSInput = new Vector2(0, 0);
        oldKeyboardInput = new Vector2(0, 0);
        //init
        yenaAttributeControl = gameObject.GetComponent<YenaAttributeControl>();
        characterController = gameObject.GetComponent<CharacterController>();
        leftJS = GameObject.FindAnyObjectByType<JoystickControl>();
        trans = transform;
        // enable Input System
        myInput = new MyInput();
        myInput.Player.Enable();
        //
        q = Quaternion.Euler(0, 45, 0);
    }
    void Update()
    {//smooth
        ///
        //
        //
        if (Yena.Instance.attribute.IsMoveAble)
        {
            inputMovementVector = myInput.Player.Movement.ReadValue<Vector2>();
            if (inputMovementVector.magnitude >= 0.1f && oldKeyboardInput.magnitude < 0.1f)
            {
                takingKeyboardInput = false;
                StartCoroutine(DelayTakingKeyBoardInput());
            }
            oldKeyboardInput = inputMovementVector;
            ////
            // chi nhan JS khi khong co' Input từ Gamepad hoac ban phim
            if (myInput.Player.Movement.ReadValue<Vector2>().magnitude == 0)
                GetMoveVectorFromJS();
            else GetMoveVectorFromInput();
            //gravity
            HandleGravity();
            //Run Animation control
            moveVector2D.x = moveVector3D.x;
            moveVector2D.y = moveVector3D.z;
            if (moveVector2D.magnitude > 0)
            {
                if (moveVector2D.magnitude > 1)
                    yenaDataBiding.Run = 1;
                else
                    yenaDataBiding.Run = moveVector2D.magnitude;
            }
            else
                yenaDataBiding.Run = 0;
            //move after all calculation above

            characterController.Move(moveVector3D * Time.deltaTime * yenaAttributeControl.current_RunSpeed);
            if (moveVector3D.magnitude > 0)
            {
                characterFoward.x = moveVector3D.x;
                characterFoward.z = moveVector3D.z;
                characterFoward.y = 0;
                trans.forward = Vector3.Slerp(trans.forward, characterFoward, Time.deltaTime + rotSpeed);
            }
        }
    }
    void GetMoveVectorFromInput()
    {
 
        // doi Input Y thanh Z
        if (takingKeyboardInput)
        {
            tempVector3d.x = Mathf.Lerp(tempVector3d.x, inputMovementVector.x, Time.deltaTime * smoothfactor);
            tempVector3d.z = Mathf.Lerp(tempVector3d.z, inputMovementVector.y, Time.deltaTime * smoothfactor);
            moveVector3D = q * tempVector3d;
        }
    }
    IEnumerator DelayTakingKeyBoardInput()
    {
        yield return new WaitForSeconds(delay_smooth);
        takingKeyboardInput = true;
    }

    void GetMoveVectorFromJS()
    {
        tempVector3d.x = Mathf.Lerp(tempVector3d.x, leftJS.dirMoveJS.x, Time.deltaTime * smoothfactor);
        tempVector3d.z = Mathf.Lerp(tempVector3d.z, leftJS.dirMoveJS.y, Time.deltaTime * smoothfactor);
        moveVector3D = q * tempVector3d;
    }
    void HandleGravity()
    {
        if (characterController.isGrounded)
        {
            moveVector3D.y = groundedGravity;
        }
        else
        {
            moveVector3D.y += gravity * Time.deltaTime;
        }
    }

}

