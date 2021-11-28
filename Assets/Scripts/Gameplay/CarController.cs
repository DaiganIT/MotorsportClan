using UnityEngine;
public class CarController : MonoBehaviour
{
    [Header("Base Properties")]
    [SerializeField] float speed;
    [SerializeField] float horizontalSpeed;

    [Header("Fake G Rotation")]
    [SerializeField] Transform rotationMesh;
    [SerializeField] Transform wheel_front_left;
    [SerializeField] Transform wheel_front_right;
    [SerializeField] Vector3 rotationAmount;
    [SerializeField] Vector3 rotationTime;

    float previousHorizontal;
    float currentRotationVelocityX;
    float currentRotationVelocityY;
    float currentRotationVelocityZ;

    bool rotateOn = false;
    bool controlsLocked = true;

    float verticalInput;
    float horizontalInput;

    private void Start()
    {
        previousHorizontal = 0;
        currentRotationVelocityZ = 0;
    }

    void Update()
    {
        var finalRotationX = Mathf.SmoothDampAngle(rotationMesh.rotation.eulerAngles.x, rotationAmount.x, ref currentRotationVelocityX, rotationTime.x);
        rotationMesh.rotation = Quaternion.Euler(finalRotationX, rotationMesh.rotation.eulerAngles.y, rotationMesh.rotation.eulerAngles.z);

        // handle input
        if (!controlsLocked) HandleInput();
    }

    void HandleInput()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        
        transform.Translate(transform.forward * vertical * speed * Time.deltaTime);
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

        var finalRotationZ = Mathf.SmoothDampAngle(rotationMesh.rotation.eulerAngles.z, rotateOn ? rotationAmount.z * horizontal : 0, ref currentRotationVelocityZ, rotationTime.z);
        var finalRotationY = Mathf.SmoothDampAngle(rotationMesh.rotation.eulerAngles.y, rotateOn ? rotationAmount.y * horizontal : 0, ref currentRotationVelocityY, rotationTime.y);
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
        rotationMesh.rotation = Quaternion.Euler(rotationMesh.rotation.eulerAngles.x, rotationAmount.y, rotationAmount.z);
        wheel_front_right.rotation = Quaternion.Euler(wheel_front_right.rotation.eulerAngles.x, rotationAmount.y, wheel_front_right.rotation.eulerAngles.z);
        wheel_front_left.rotation = Quaternion.Euler(wheel_front_left.rotation.eulerAngles.x, rotationAmount.y, wheel_front_left.rotation.eulerAngles.z);
    }
    [ContextMenu("TestLeft")]
    public void RotateLeft()
    {
        rotationMesh.rotation = Quaternion.Euler(rotationMesh.rotation.eulerAngles.x, -rotationAmount.y, -rotationAmount.z);
        wheel_front_right.rotation = Quaternion.Euler(wheel_front_right.rotation.eulerAngles.x, -rotationAmount.y, wheel_front_right.rotation.eulerAngles.z);
        wheel_front_left.rotation = Quaternion.Euler(wheel_front_left.rotation.eulerAngles.x, -rotationAmount.y, wheel_front_left.rotation.eulerAngles.z);
    }
}
