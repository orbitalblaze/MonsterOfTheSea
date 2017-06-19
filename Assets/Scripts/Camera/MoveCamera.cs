using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public int zoomSpeed;
    public int orthographicSizeMin;
    public int orthographicSizeMax;
    private bool viewScreenPanning = false;
    private float viewScreenOldMouseX = 0;
    private float viewScreenOldMouseY = 0;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(horizontalSpeed * Input.GetAxis("Horizontal"), verticalSpeed * Input.GetAxis("Vertical"), 0);


        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            Camera.main.orthographicSize -= zoomSpeed;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
        {
            Camera.main.orthographicSize += zoomSpeed;
        }
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin,
            orthographicSizeMax);

        //Hold Right Mouse Button to pan the screen in a direction 
        
        if (Input.GetMouseButtonDown(1))
        {
            print("Panning...");
            viewScreenOldMouseX = Input.mousePosition.x;
            viewScreenOldMouseY = Input.mousePosition.y;
            viewScreenPanning = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            print("Not panning...");
            viewScreenPanning = false;
        }
        if (viewScreenPanning)
        {
            Vector3 translateVector = new Vector3((viewScreenOldMouseX - Input.mousePosition.x) / (1 / (Camera.main.orthographicSize / (16 * orthographicSizeMin))),  (viewScreenOldMouseY - Input.mousePosition.y) / (1 / (Camera.main.orthographicSize / (16 * orthographicSizeMin))), 0);
            transform.Translate(translateVector.x, translateVector.y, translateVector.z);
            viewScreenOldMouseX = Input.mousePosition.x;
            viewScreenOldMouseY = Input.mousePosition.y;
            
        }


// If panning, find the angle to pan based on camera angle not screen 
        
    }
}