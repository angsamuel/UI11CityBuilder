 
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float panSpeed = 20f;
    public float rotSpeed = 10f;
    public float zoomSpead = 50f;
    public float borderWidth = 10f;
    public bool edgeScrooling = true;
    public Transform target;
    public Vector3 offset;
    public Camera cam;

    private float zoomMin = 11.0f;
    private float zoomMax = 49.0f;

    void LateUpdate ()
    {
        transform.position = target.position + offset;
    }
    void Start()
    {
        cam = Camera.main;
    }
    void Movement()
    {
        Vector3 pos = transform.position;
        Vector3 forward = transform.forward;
        forward.y = 0;
        forward.Normalize();
        Vector3 right = transform.right;
        right.y = 0;
        right.Normalize();
    }
    void Zoom()
    {
        Vector3 camPos = cam.transform.position;
        float distance = Vector3.Distance(transform.position, cam.transform.position);
    }
    

    void Update()
    {
        Movement();
        Zoom();
    }
}
