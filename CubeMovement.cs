
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public GameObject ObjectToRotate;

    public float objectRotationSpeed = 20f;
    public Vector3 RotateAmount;
    public float xAngle, yAngle, zAngle;
    private GameObject TerrainCube;
    public void Rotate(Vector3 axis, float angle, Space relativeTo = Space.Self)
    {

    }
    void FixedUpdate()
    {
        ObjectToRotate.transform.Rotate(xAngle, yAngle, zAngle);
        
        //I'm not sure how to input the VR controller for the rotation 
        
    }

    void Rotate()
    {

        Vector3 eulerRotation = new Vector3(0, 0, transform.eulerAngles.z);

        transform.rotation = Quaternion.Euler(eulerRotation);
    }
    
}   

