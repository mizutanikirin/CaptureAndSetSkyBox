using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkyboxSampleManager : MonoBehaviour {

    // ChangeSkyBox
    public CaptureAndSetSkyBox captureAndSetSkyBox;

    // Cube作成
    public GameObject cubePrefab;
    public GameObject parentObj;
    public float posRange;

    // camera回転
    public Camera targetCamera;
    private Vector3 lastMousePosition;
    private Vector3 cameraAngle;

    private void Start() {
        cameraAngle = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CameraUpdate();

        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) RandomCube();
        }

        if (Input.GetKeyUp(KeyCode.Space)) RandomCube();
    }

    public void Capture() {
        captureAndSetSkyBox.Capture();
        DeleteAllGameObject(parentObj, false);
    }


    //----------------------------------
    //  cube作成
    //----------------------------------
    #region cube作成
    private void RandomCube() {
        CreateObj(
            cubePrefab, parentObj, "cube",
            new Vector3(
                targetCamera.transform.position.x + Random.Range(-posRange, posRange),
                targetCamera.transform.position.y + Random.Range(-posRange, posRange),
                targetCamera.transform.position.z + Random.Range(-posRange, posRange)
            ),
            Vector3.zero, Vector3.one
        );
    }

    private GameObject CreateObj(GameObject prefab, GameObject parentObj, string name, Vector3 pos, Vector3 rotate, Vector3 scale) {
        GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        obj.name = name;
        obj.transform.SetParent(parentObj.transform, false);
        obj.transform.position = pos;
        obj.transform.localScale = scale;
        obj.transform.rotation = Quaternion.Euler(rotate.x, rotate.y, rotate.z);

        return obj;
    }

    private void DeleteAllGameObject(GameObject parentObj, bool delParent) {
        List<GameObject> allGameObj = GetAllGameObject(parentObj);
        foreach (GameObject thisObj in allGameObj) {
            Destroy(thisObj);
        }

        if (delParent) Destroy(parentObj);
    }

    private List<GameObject> GetAllGameObject(GameObject parentObj) {
        List<GameObject> allChildren = new List<GameObject>();
        GetChildren(parentObj, ref allChildren);
        return allChildren;
    }

    // 子要素を取得してリストに追加
    private void GetChildren(GameObject obj, ref List<GameObject> allChildren) {
        Transform children = obj.GetComponentInChildren<Transform>();
        // 子要素がいなければ終了
        if (children.childCount == 0) {
            return;
        }
        foreach (Transform ob in children) {
            allChildren.Add(ob.gameObject);
            GetChildren(ob.gameObject, ref allChildren);
        }
    }
    #endregion

    //----------------------------------
    //  camera回転
    //----------------------------------
    private void CameraUpdate() {

        if (Input.GetMouseButtonDown(0)) {

            cameraAngle = targetCamera.transform.localEulerAngles;
            lastMousePosition = Input.mousePosition;

        } else if (Input.GetMouseButton(0)) {

            cameraAngle.y += (Input.mousePosition.x - lastMousePosition.x) * 0.1f;
            cameraAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * 0.1f;
            targetCamera.gameObject.transform.localEulerAngles = cameraAngle;

            lastMousePosition = Input.mousePosition;
        }

    }
}
