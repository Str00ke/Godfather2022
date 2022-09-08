using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInput : MonoBehaviour
{
    private Transform startPosition;

    public Transform QPosition;
    public Transform DPosition;
    public Transform SpacePosition;

    // Rock Falling speed
    public float rockFallingSpeed = 0.7F;

    public AnimationCurve animationCurve;

    public bool isActiveQ;
    public bool isActiveD;
    public bool isActiveSpace;

    private PlayerControls pControls;


    private void Start()
    {
        pControls = FindObjectOfType<PlayerControls>();

        isActiveQ = true;
        isActiveD = true;
        isActiveSpace = true;
        startPosition = gameObject.transform;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && isActiveQ)
        {
            Debug.Log("Q");
        }
        if (Input.GetKey(KeyCode.Space) && isActiveSpace)
        {
            Debug.Log("Space");
        }
        if (Input.GetKey(KeyCode.D) && isActiveD)
        {
            Debug.Log("D");
        }
    }



    public void EnableInput(RockFall.InputBlock blockedInput, bool enable = true)
    {
        switch (blockedInput)
        {
            case RockFall.InputBlock.Q:
                isActiveQ = enable;
                pControls.baseVec.x = enable ? 1 : 0;
                break;
            case RockFall.InputBlock.D:
                isActiveD = enable;
                pControls.baseVec.y = enable ? 1 : 0;
                break;
            case RockFall.InputBlock.Space:
                isActiveSpace = enable;
                pControls.baseVec.z = enable ? 1 : 0;
                break;
            default:
                break;
        }
    }
}
