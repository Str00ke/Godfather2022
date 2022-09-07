using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private bool customSize;
    [SerializeField] private float leftLimitThresold;
    [SerializeField] private float rightLimitThresold;
    [SerializeField] private GameObject player;

    private Camera cam;
    private float verticalSize;
    private float horizontalSize;

    private void Awake()
    {
        cam = Camera.main;
        verticalSize = Camera.main.orthographicSize * 2.0f;
        horizontalSize = verticalSize * Screen.width / Screen.height;
    }

    void Start()
    {

    }

    void Update()
    {
        if (player.transform.position.x >= (cam.transform.position.x + horizontalSize / 2) - leftLimitThresold)
            cam.transform.position = new Vector3(cam.transform.position.x + horizontalSize - rightLimitThresold, cam.transform.position.y, -10);
    }
}
