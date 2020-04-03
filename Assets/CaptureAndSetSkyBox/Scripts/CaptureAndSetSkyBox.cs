using UnityEngine;

public class CaptureAndSetSkyBox : MonoBehaviour {

    // cameraにAttachしているSkyboxを指定する。
    public Skybox customSkybox;

    // Asset内にskyboxのテクスチャを用意してそこに上書きしていく
    public Texture2D skyboxBaseTexture;

    // キャプチャするテクスチャの幅
    public int imageWidth = 1024;

    private GameObject cameraObj;

    // Start is called before the first frame update
    void Start() {
        SkyboxEnable(false);
        cameraObj = customSkybox.gameObject;
    }

    // パノラマでキャプチャしてSkyBoxに割り当てる
    public void Capture() {
        byte[] bytes = I360Render.Capture(imageWidth, false);
        if (bytes != null) {
            Debug.Log("Capture 360");

            skyboxBaseTexture.LoadImage(bytes);
            customSkybox.material.mainTexture = skyboxBaseTexture;
            customSkybox.material.SetInt("_Rotation", Mathf.RoundToInt(-cameraObj.transform.localRotation.eulerAngles.y + 90));

            SkyboxEnable(true);
        }

    }

    public void SkyboxEnable(bool enable) {
        customSkybox.enabled = enable;
    }
}
