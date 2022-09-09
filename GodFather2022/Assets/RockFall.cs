using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFall : MonoBehaviour
{
    [SerializeField]
    private BlockInput blockInput;

    [SerializeField]
    private InputBlock inputToBlock;

    private Transform inputBlockPos;


    private Vector3 startPos;


    private void Awake()
    {
        startPos = transform.position;
    }

    private void Start()
    {
        switch (inputToBlock)
        {
            case InputBlock.Q:
                inputBlockPos = blockInput.QPosition;
                break;
            case InputBlock.D:
                inputBlockPos = blockInput.DPosition;
                break;
            case InputBlock.Space:
                inputBlockPos = blockInput.SpacePosition;
                break;
            default:
                break;
        }
    }

    private void Update()
    {
    }

    public IEnumerator FallCor(GameObject trigger)
    {
        Vector3 start = this.gameObject.transform.position;
        Vector3 end = inputBlockPos.position;
        float index = 0;
        float t = 0;
        FindObjectOfType<AudioManager>().Play("RockFall");
        while (index < 1)
        {
            this.gameObject.transform.position = Vector3.Lerp(start, end, t);
            t = blockInput.animationCurve.Evaluate(index);
            index += Time.deltaTime * blockInput.rockFallingSpeed;
            yield return null;
        }
        transform.position = end;
        FindObjectOfType<AudioManager>().Stop("RockFall");
        FindObjectOfType<AudioManager>().Play("RockTouchGround");
        blockInput.EnableInput(inputToBlock, false);
        Destroy(trigger);
        yield return null;
    }

    private void DestroyRock()
    {
        blockInput.EnableInput(inputToBlock);
        //Destroy(this.gameObject);
        transform.position = startPos;
        FindObjectOfType<AudioManager>().Play("BreakRock");
        
    }

    public enum InputBlock
    {
        Q,
        D,
        Space
    }

    public void GetHit()
    {
        DestroyRock();
    }
}
