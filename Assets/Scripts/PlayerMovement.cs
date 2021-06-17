using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float forwardSpeed;
    public float Sensitivity;
    public float rotationSensitivity;

    private Touch touch;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        sideWaysMovement();
    }

    void sideWaysMovement()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                // Making player Move sideways on touch
                float xSlide = transform.position.x + touch.deltaPosition.x * Sensitivity;
                transform.position = new Vector3(xSlide, transform.position.y, transform.position.z);

                // Rotating the player based on sidewaysMovement
                transform.Rotate(Vector3.up * touch.deltaPosition.x / ( rotationSensitivity * 10 + 10));
            }
        }
    }
}
