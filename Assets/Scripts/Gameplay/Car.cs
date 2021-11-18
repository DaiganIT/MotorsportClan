using UnityEngine;
public class Car : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float rotationAmountX;
    [SerializeField] float rotationAmountY;
    [SerializeField] float rotationAmountZ;
    [SerializeField] float rotationTimeX;
    [SerializeField] float rotationTimeY;
    [SerializeField] float rotationTimeZ;
    [SerializeField] Transform rotationMesh;
    [SerializeField] Transform wheel_front_left;
    [SerializeField] Transform wheel_front_right;

    float previousHorizontal;
    float currentRotationVelocityX;
    float currentRotationVelocityY;
    float currentRotationVelocityZ;

    bool rotateOn = false;

    private void Start()
    {
        previousHorizontal = 0;
        currentRotationVelocityZ = 0;
    }

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);

        var finalRotationX = Mathf.SmoothDampAngle(rotationMesh.rotation.eulerAngles.x, rotationAmountX, ref currentRotationVelocityX, rotationTimeX);
        rotationMesh.rotation = Quaternion.Euler(finalRotationX, rotationMesh.rotation.eulerAngles.y, rotationMesh.rotation.eulerAngles.z);

        // handle input
        HandleInput();
    }

    void HandleInput()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(transform.right * horizontal * horizontalSpeed * Time.deltaTime);

        // add a small rotation on the z axis
        if (horizontal != 0 && previousHorizontal == 0)
        {
            rotateOn = true;
            // rotate mesh to rotationAmount
        }
        else if (horizontal == 0 && previousHorizontal != 0)
        {
            // rotate mesh to 0
            rotateOn = false;
        }

        var finalRotationZ = Mathf.SmoothDampAngle(rotationMesh.rotation.eulerAngles.z, rotateOn ? rotationAmountZ * horizontal : 0, ref currentRotationVelocityZ, rotationTimeZ);
        var finalRotationY = Mathf.SmoothDampAngle(rotationMesh.rotation.eulerAngles.y, rotateOn ? rotationAmountY * horizontal : 0, ref currentRotationVelocityY, rotationTimeY);
        rotationMesh.rotation = Quaternion.Euler(rotationMesh.rotation.eulerAngles.x, finalRotationY, finalRotationZ);
        wheel_front_right.rotation = Quaternion.Euler(wheel_front_right.rotation.eulerAngles.x, finalRotationY, wheel_front_right.rotation.eulerAngles.z);
        wheel_front_left.rotation = Quaternion.Euler(wheel_front_left.rotation.eulerAngles.x, finalRotationY, wheel_front_left.rotation.eulerAngles.z);

        previousHorizontal = horizontal;
    }

    [ContextMenu("RestoreRotation")]
    public void RestoreRotation()
    {
        rotationMesh.rotation = Quaternion.Euler(rotationMesh.rotation.eulerAngles.x, 0, 0);
        wheel_front_right.rotation = Quaternion.Euler(wheel_front_right.rotation.eulerAngles.x, 0, wheel_front_right.rotation.eulerAngles.z);
        wheel_front_left.rotation = Quaternion.Euler(wheel_front_left.rotation.eulerAngles.x, 0, wheel_front_left.rotation.eulerAngles.z);
    }
    [ContextMenu("TestRight")]
    public void RotateRight()
    {
        rotationMesh.rotation = Quaternion.Euler(rotationMesh.rotation.eulerAngles.x, rotationAmountY, rotationAmountZ);
        wheel_front_right.rotation = Quaternion.Euler(wheel_front_right.rotation.eulerAngles.x, rotationAmountY, wheel_front_right.rotation.eulerAngles.z);
        wheel_front_left.rotation = Quaternion.Euler(wheel_front_left.rotation.eulerAngles.x, rotationAmountY, wheel_front_left.rotation.eulerAngles.z);
    }
    [ContextMenu("TestLeft")]
    public void RotateLeft()
    {
        rotationMesh.rotation = Quaternion.Euler(rotationMesh.rotation.eulerAngles.x, -rotationAmountY, -rotationAmountZ);
        wheel_front_right.rotation = Quaternion.Euler(wheel_front_right.rotation.eulerAngles.x, -rotationAmountY, wheel_front_right.rotation.eulerAngles.z);
        wheel_front_left.rotation = Quaternion.Euler(wheel_front_left.rotation.eulerAngles.x, -rotationAmountY, wheel_front_left.rotation.eulerAngles.z);
    }
}
