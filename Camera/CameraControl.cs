using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class CameraControl : MonoBehaviour
{
    //public Transform target;
    //public Transform trans;
    //public Camera trueCamera;
    //private Vector2 m_Rotation;
    //public float rotateSpeed;
    //public Transform rootcam;
    //public float limit_Top;
    //public float limit_Bottom;
    //private float invert_limit_Top;
    //private float invert_limit_Bottom;
    //private const float _threshold = 0 / 0.01f;
    //MyInput myInput;
    //float horizontal_Rotate = 0;
    //float vertical_Rotate = 0;
    //private Vector3 camera_Rotate;
    //bool waited = false;
    //public CameraData[] camData;
    //public CameraData currentData;
    //public Dictionary<CameraState,CameraData> dic_CameraState=new Dictionary<CameraState, CameraData>();
    //public Transform aim;
    //public Transform TrueCam_pos;
    //public JoystickControl rightJoystickControl;
    //public float rotateSpeedMultiplier_rightJS = 2;
    //private void Awake()
    //{
    //    invert_limit_Top = 0 - limit_Bottom;
    //    invert_limit_Bottom = 0 - limit_Top;
    //    trans = transform;
    //    myInput = MyInputSingleton.Instance.myInput;
    //    foreach(CameraData c in camData)
    //    {
    //        dic_CameraState.Add(c.state, c);
    //    }
    //    ChangeCameraState(CameraState.Move);
    //}

    //private IEnumerator Start()
    //{
    //    yield return new WaitForSeconds(2);
    //     waited = true;
    //}

    //private void LateUpdate()
    //{
    //    // thay doi mode camera theo stance cua nhan vat
    //    if (PlayerMovementControl.stance == playerStance.aim)
    //        ChangeCameraState(CameraState.Aim);
    //    else if(PlayerMovementControl.stance == playerStance.crouch)
    //    {
    //        ChangeCameraState(CameraState.Crouch);
    //    }    
    //    else ChangeCameraState(CameraState.Move);
        
    //    trans.position = target.position;
    //    if (waited)
    //    {
    //        Vector2 mouse_Delta = myInput.Player.Look.ReadValue<Vector2>();
    //        if(mouse_Delta.sqrMagnitude>0)
    //        RotateRootCam(mouse_Delta);
    //        else
    //        //xoay bang JS
    //        {
    //            rightJoystickControl.dirMoveJS = new Vector2(rightJoystickControl.dirMoveJS.x*rotateSpeedMultiplier_rightJS, rightJoystickControl.dirMoveJS.y * -1*rotateSpeedMultiplier_rightJS);
    //            RotateRootCam(rightJoystickControl.dirMoveJS);
    //        }    
    //    }

    //    // // dich chuyen camera theo tung state
    //    TrueCam_pos.localPosition = Vector3.Lerp(TrueCam_pos.localPosition, currentData.localPos, Time.deltaTime * 6);
    //    trueCamera.fieldOfView = Mathf.Lerp(trueCamera.fieldOfView,currentData.FOV,Time.deltaTime * 6);
    //    TrueCam_pos.forward = aim.position - TrueCam_pos.position;
        
    //}
   
   
   
    //private void RotateRootCam(Vector2 delta)
    //{
    //    if (delta.sqrMagnitude > _threshold)
    //    {
    //        float scaledRotateSpeed = rotateSpeed * Time.deltaTime;
    //        horizontal_Rotate += delta.x * scaledRotateSpeed;
    //        vertical_Rotate += delta.y * scaledRotateSpeed;
    //        vertical_Rotate = Mathf.Clamp(vertical_Rotate, invert_limit_Bottom, invert_limit_Top);
    //        camera_Rotate = new Vector3(vertical_Rotate, horizontal_Rotate, 0);
    //        trans.localEulerAngles = camera_Rotate;
    //    }

    //}
    //public enum CameraState
    //{
    //    Move=1,
    //    Aim=2,
    //    Crouch=3
    //}
    //[Serializable]
    //public class CameraData
    //{
    //    public CameraState state;
    //    public Vector3 localPos;
    //    public float FOV;
    //}
   
    //public void ChangeCameraState(CameraState state)
    //{
    //    currentData=dic_CameraState[state];
    //}
}
