using UnityEngine;
using System.Collections;

public class mouse_controller : MonoBehaviour {
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 };
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15.0f;
    public float sensitivityY = 15.0f;
    public float minX = -360.0f;
    public float maxX = 360.0f;
    public float minY = -60.0f;
    public float maxY = 60.0f;

	private float rotY = 0.0f;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotX = transform.localEulerAngles.y + mouseX + sensitivityX;

            rotY += mouseY + sensitivityY;
            rotY = Mathf.Clamp(rotY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotY, rotX, 0);
        }else if(axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, mouseX * sensitivityX, 0);
        }else
        {
            rotY += mouseY * sensitivityY;
            rotY = Mathf.Clamp(rotY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotY, transform.localEulerAngles.y, 0);
        }
	}

	void OnMouseDown(){
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
}
