using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScroller : MonoBehaviour
{
    [SerializeField] private float defaultSpeed;

    private float currentSpeed;
    private float acceleratedSpeed;

    [SerializeField] private float yEnd;

    void Start()
    {
        currentSpeed = defaultSpeed;
        acceleratedSpeed = defaultSpeed * 3f;

        StartCoroutine(Scroll());   
    }

    // Update is called once per frame
    void Update()
    {
        //If any input from the stick > the slide goes faster
        var absoluteHorizontal = Mathf.Abs(Input.GetAxisRaw("Horizontal"));
        var absoluteVertical = Mathf.Abs(Input.GetAxisRaw("Vertical"));

        if (absoluteHorizontal > 0f || absoluteVertical> 0f)
            currentSpeed = acceleratedSpeed;

        else
            currentSpeed = defaultSpeed;
    }

    private IEnumerator Scroll()
    {
        while (true)
        {
            transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);
            if (transform.localPosition.y >= yEnd)
                break;
            yield return null;
        }
        FindObjectOfType<GameManager>().MyLoadScene(0);
    }
}
