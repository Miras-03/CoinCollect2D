using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private Vector3 vector;

    private float horizontalInput;

    private void Update()
    {
        GetInput();
        Move();
    }

    private void GetInput() => horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * 10;

    private void Move()
    {
        vector = transform.localPosition;
        vector.x += horizontalInput;
        transform.localPosition = vector;
    }
}
