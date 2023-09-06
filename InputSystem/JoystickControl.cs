using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class JoystickControl : MonoBehaviour,IEndDragHandler,IDragHandler,IBeginDragHandler, IPointerDownHandler, IPointerUpHandler
{ 
  public RectTransform rect_JS;
    public RectTransform knod_JS;
    public RectTransform bound_JS;
    public float bound_radius = 180;
    [NonSerialized]
    public Vector2 dirMoveJS=Vector2.zero;
    public float drag_limit = 400;
    private void Awake()
    {
       
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
  
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 screenPos = eventData.position;
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect_JS,screenPos,null,out localPoint);
        // gioi han window khi drag
        if (localPoint.magnitude > drag_limit)
        {

            localPoint = localPoint.normalized * drag_limit;
        }
            knod_JS.anchoredPosition = localPoint;

            // limit Knod trong vung Bound
            float dragDistance = knod_JS.anchoredPosition.magnitude;
            Vector2 dir_pivot_to_knod = knod_JS.anchoredPosition;
            dir_pivot_to_knod.Normalize();
        // keo bound theo knod
            if (dragDistance > bound_radius)
            {
                bound_JS.anchoredPosition = knod_JS.anchoredPosition - dir_pivot_to_knod * bound_radius;
            }
        }
    
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        knod_JS.anchoredPosition = Vector2.zero;
        bound_JS.anchoredPosition = Vector2.zero;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    private void Update()
    { // dieu khien nhan vat di chuyen
        dirMoveJS.x=knod_JS.anchoredPosition.x/bound_radius/2;
        dirMoveJS.y=knod_JS.anchoredPosition.y/bound_radius/2;
        //dirMoveJS.Normalize();
    }



}
