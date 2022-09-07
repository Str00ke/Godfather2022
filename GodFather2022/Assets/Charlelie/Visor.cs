using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Visor : MonoBehaviour
{
    [SerializeField] private RectTransform zone;
       
    void Start()
    {
        
    }


    void Update()
    {
        transform.position = Input.mousePosition;
        float xVal = Mathf.Clamp(transform.position.x, zone.rect.xMin, zone.rect.xMax);
        float yVal = Mathf.Clamp(transform.position.y, zone.rect.yMin, zone.rect.yMax);
        transform.position = zone.transform.position + new Vector3(xVal, yVal, 0);
    }
}
