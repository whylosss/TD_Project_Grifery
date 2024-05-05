using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _movementRange = 150f;
    [SerializeField] private float _normalSpeed = 20f;
    [SerializeField] private float _maxSpeed = 50f;

    private float _speed;

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _maxSpeed;
        }

        else
        {
            _speed = _normalSpeed;
        }

        float horizontalMovement = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        Vector3 currentPosition = transform.position;
        float newX = Mathf.Clamp(currentPosition.x + horizontalMovement, 0, _movementRange);
        transform.position = new Vector3(newX, currentPosition.y, currentPosition.z);
    }
}
