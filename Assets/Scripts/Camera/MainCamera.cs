using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
    public float axisXSpeed = 0.5f;
    public float axisYSpeed = 0.5f;
    public float axisXSensitivity = 0.6f;
    public float axisYSensitivity = 0.6f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 translate;
        translate.x = axisXSpeed * Input.GetAxis("Mouse X");
        translate.y = axisYSpeed * Input.GetAxis("Mouse Y");
        translate.z = 0;

        transform.Translate(translate, Space.World);
    }
}
