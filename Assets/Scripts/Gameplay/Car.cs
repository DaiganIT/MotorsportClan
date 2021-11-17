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

        previousHorizontal = horizontal;
    }
}
