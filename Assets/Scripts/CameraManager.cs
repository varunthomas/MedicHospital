using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Vector3 touchStart;
    float zoomOutMax = 8;
    float zoomInMax = 1;
    float mapMinX, mapMaxX, mapMinY, mapMaxY;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        mapMinX = -20f;
        mapMaxX = 20f;
        mapMinY = -20f;
        mapMaxY = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            touchStart = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
            float difference = currentMagnitude - prevMagnitude;
            zoom(difference*0.1f);

        }
        else if(Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position = ClampCamera(cam.transform.position + direction);
            //Debug.Log("Camera pos is " + cam.transform.position + " direction " + direction + " toucStart " + touchStart + " cam screen to world " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    void zoom(float increment)
    {
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - increment, zoomInMax, zoomOutMax);
        cam.transform.position = ClampCamera(cam.transform.position);
    }

    Vector3 ClampCamera(Vector3 targetPos)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize*cam.aspect;

        float minX = mapMinX + camWidth;
        float maxY = mapMaxY - camHeight;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;

        float newX = Mathf.Clamp(targetPos.x, minX, maxX);
        float newY = Mathf.Clamp(targetPos.y, minY, maxY);

        return new Vector3(newX, newY, targetPos.z);
    }
}
