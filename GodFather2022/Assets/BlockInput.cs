using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInput : MonoBehaviour
{
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private Transform endPosition;

    // Time when the movement started.
    private float startTime;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Total distance between the markers.
    private float journeyLength;

    [SerializeField]
    private GameObject gameObject;
    [SerializeField]
    AnimationCurve animationCurve;

    public bool isActiveQ;
    public bool isActiveEscape;
    public bool isActiveD;

    private void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        startPosition = gameObject.transform;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startPosition.position, endPosition.position);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(FallCor(startPosition, endPosition, gameObject));
        }

        if (Input.GetKey(KeyCode.Q) && isActiveQ)
        {
            Debug.Log("Q");
        }
        if (Input.GetKey(KeyCode.Escape) && isActiveEscape)
        {
            Debug.Log("Escape");
        }
        if (Input.GetKey(KeyCode.D) && isActiveD)
        {
            Debug.Log("D");
        }
    }

    IEnumerator FallCor(Transform sPos, Transform ePos, GameObject fallingObject)
    {
        Vector3 start = sPos.position;
        Vector3 end = ePos.position;
        float index = 0;
        float t = 0;

        while (index < 1)
        {
            fallingObject.transform.position = Vector3.Lerp(start, end, t);
            t = animationCurve.Evaluate(index);
            index += Time.deltaTime * speed;
            yield return null;
        }

        DisableInput();

        yield return null;
    }

    private void DisableInput()
    {
        
    }
}
