using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TouchEffectHandler : MonoBehaviour
{
    public RectTransform RootUI;
    public GameObject touchEffect;
    public GraphicRaycaster raycaster;

    private void Awake()
    {
       
    }

  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount>0)
        //{
        //    //
        //    Debug.Log("touched");
        //    //
        //    Touch touch= Input.GetTouch(0);
        //    touchEffect.gameObject.SetActive(true);
        //    touchEffect.transform.position = touch.position;

        //}    
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mposition = Input.mousePosition;
            mposition.z = 0;
            touchEffect.gameObject.SetActive(true);
            touchEffect.transform.position=mposition;
            
        }
    }
}
