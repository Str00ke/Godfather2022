using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Visor : MonoBehaviour
{
    [SerializeField] private RectTransform zone;
    [SerializeField] private float range;
    [SerializeField] private float yThresold;

    private RectTransform rT;

    private void Awake()
    {
        rT = GetComponent<RectTransform>();
    }

    void Start()
    {
        transform.position = zone.rect.center;
    }


    void Update()
    {

        Vector2 vec = Joystick.current.stick.ReadValue();


        if (vec.x > 0)
        {
            if (transform.localPosition.x + vec.x > zone.rect.xMax) vec.x = 0;
            Debug.Log("VEC X: " + vec.x);
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

        transform.position += (Vector3)vec;

        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    void Shoot()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, range);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].transform.CompareTag("Rock"))
            {
                cols[i].gameObject.GetComponent<RockFall>().GetHit();
                break;
            }
        }
    }
}
