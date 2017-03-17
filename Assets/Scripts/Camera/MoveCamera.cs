using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    public float horizontalSpeed = 1f;
    public float verticalSpeed = 1f;


	// Update is called once per frame
	void Update ()
	{
	    transform.Translate(horizontalSpeed * Input.GetAxis("Horizontal"), verticalSpeed * Input.GetAxis("Vertical"), 0);
	}
}
