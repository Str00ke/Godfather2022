using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Visor : MonoBehaviour
{
    [SerializeField] private RectTransform zone;
    [SerializeField] private float range;
    [SerializeField] private float yThresold;
    [SerializeField] private float speed;

    private RectTransform rT;

    private bool hasShot = false;

    private void Awake()
    {
        rT = GetComponent<RectTransform>();
    }

    void Start()
    {
        transform.position = zone.transform.position + (Vector3)zone.rect.center;
    }


    void Update()
    {
        //Get Joystick Names
        string[] temp = Input.GetJoystickNames();

        //Check whether array contains anything
        if (temp.Length > 0)
        {
            //Iterate over every element
            for (int i = 0; i < temp.Length; ++i)
            {
                //Check if the string is empty or not
                if (!string.IsNullOrEmpty(temp[i]))
                {
                    //Not empty, controller temp[i] is connected
                    //Debug.Log("Controller " + i + " is connected using: " + temp[i]);
                }
                else
                {
                    //If it is empty, controller i is disconnected
                    //where i indicates the controller number
                    //Debug.Log("Controller: " + i + " is disconnected.");

                }
            }
        }
        if (string.IsNullOrEmpty(temp[0]))
        {
            //Debug.Log(transform.localPosition.x);
            //Debug.Log(zone.rect.xMin);
            //Debug.Log(zone.rect.xMax);
            transform.position = Input.mousePosition;
            float xVal = Mathf.Clamp(transform.localPosition.x, -80, 80);
            float yVal = Mathf.Clamp(transform.localPosition.y, zone.rect.yMin, zone.rect.yMax);
            Debug.Log("XVAL: " + xVal);
            transform.position = zone.transform.position + new Vector3(xVal, yVal, 0);
            if (Input.GetMouseButtonDown(0))
            { 
                Shoot(); 
            }
        }
        else
        {

            Vector2 vec = Joystick.current.stick.ReadValue();


            if (vec.x > 0)
            {
                if (transform.localPosition.x + vec.x > zone.rect.xMax) vec.x = 0;
            }
            else if (vec.x < 0)
            {
                if (transform.localPosition.x + vec.x < zone.rect.xMin) vec.x = 0;
            }

            if (vec.y > 0)
            {
                if (rT.anchoredPosition.y + vec.y + yThresold > zone.rect.yMax) vec.y = 0;
            }
            else if (vec.y < 0)
            {
                if (rT.anchoredPosition.y + vec.y < zone.rect.yMin) vec.y = 0;
            }

            transform.position += (Vector3)vec * speed;

            if (Joystick.current.trigger.isPressed && !hasShot) Shoot();
            else if (!Joystick.current.trigger.isPressed && hasShot) hasShot = false;
        }

    }

    void Shoot()
    {
        hasShot = true;
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, range);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].transform.CompareTag("Rock"))
            {
                cols[i].gameObject.GetComponent<RockFall>().GetHit();
                break;
            }
        }
        FindObjectOfType<AudioManager>().Play("ShootMiss");
    }
}
