using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private bool customSize;
    [SerializeField] private float leftLimitThresold;
    [SerializeField] private float rightLimitThresold;
    [SerializeField] private GameObject player;
    [SerializeField] private Material changeScreenMat;
    

    private Deathzone deathzoneScript;
    private Camera cam;
    private float verticalSize;
    private float horizontalSize;

    private void Awake()
    {
        cam = Camera.main;
        deathzoneScript = FindObjectOfType<Deathzone>();
        verticalSize = Camera.main.orthographicSize * 2.0f;
        horizontalSize = verticalSize * Screen.width / Screen.height;
    }

    void Start()
    {
        GameManager.instance.UpdateBackground();
        Texture2D tex = RTImage();
        changeScreenMat.SetTexture("_PrevScreenTex", tex);
        changeScreenMat.SetFloat("_isActive", 1);
    }

    void Update()
    {
        if (player == null) return;

        if (player.transform.position.x >= (cam.transform.position.x + horizontalSize / 2) - leftLimitThresold)
            ChangeScreen();
    }

    void ChangeScreen()
    {
        //Texture2D tex = RTImage();
        //changeScreenMat.SetTexture("_PrevScreenTex", tex);
        changeScreenMat.SetFloat("_isActive", 1);
        GameManager.instance.UpdateBackground();
        cam.transform.position = new Vector3(cam.transform.position.x + horizontalSize - rightLimitThresold, cam.transform.position.y, -10);
        deathzoneScript.Ison = false;
        deathzoneScript.ChangeInt();
    }

    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }

    private Texture2D RTImage()
    {
        int mWidth = cam.pixelWidth;
        int mHeight = cam.pixelHeight;
        Rect rect = new Rect(0, 0, mWidth, mHeight);
        RenderTexture renderTexture = new RenderTexture(mWidth, mHeight, 24);
        Texture2D screenShot = new Texture2D(mWidth, mHeight, TextureFormat.RGBA32, false);

        //cam.targetTexture = renderTexture;
        //cam.Render();

        ScreenCapture.CaptureScreenshotIntoRenderTexture(renderTexture);

        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(rect, 0, 0);
        screenShot.Apply();

        cam.targetTexture = null;
        RenderTexture.active = null;

        Destroy(renderTexture);
        renderTexture = null;
        return screenShot;
    }

}
