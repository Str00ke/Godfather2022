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
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(FallCor());
    }

    public IEnumerator FallCor()
    {
        Vector3 start = this.gameObject.transform.position;
        Vector3 end = inputBlockPos.position;
        float index = 0;
        float t = 0;

        while (index < 1)
        {
            this.gameObject.transform.position = Vector3.Lerp(start, end, t);
            t = blockInput.animationCurve.Evaluate(index);
            index += Time.deltaTime * blockInput.rockFallingSpeed;
            yield return null;
        }

        blockInput.EnableInput(inputToBlock, false);

        yield return null;
    }

    private void DestroyRock()
    {
        blockInput.EnableInput(inputToBlock);
        Destroy(this.gameObject);
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
