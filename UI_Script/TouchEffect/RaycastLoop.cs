using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RaycastLoop : MonoBehaviour,IPointerDownHandler
{
    // Start is called before the first frame update
    GraphicRaycaster graphicsRaycaster;

    public void OnPointerDown(PointerEventData eventData)
    {

        Debug.Log("aa");
        var allHits = new List<RaycastResult>();

        var hits = new List<RaycastResult>();
        graphicsRaycaster.Raycast(eventData, hits);

        allHits.AddRange(hits);
    }

    void Awake()
    {
        graphicsRaycaster = GetComponent<GraphicRaycaster>();
       


    }
    void Update()
    {
        
    }
}
