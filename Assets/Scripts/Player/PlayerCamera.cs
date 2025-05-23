using UnityEngine;

public struct CameraInput
{
    public Vector2 Look;
    public bool usingController;
}

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private float controllerSensitivity = 1.0f;

    private Vector3 _eulerAngles;

    public void Initialise(Transform target)
    {
        transform.position = target.position;
        transform.eulerAngles = _eulerAngles = target.eulerAngles;
    }

    public void UpdateRotation(CameraInput input)
    {
        float sensitivity;

        if (input.usingController)
            sensitivity = controllerSensitivity;
        else
            sensitivity = mouseSensitivity;

        _eulerAngles += new Vector3(-input.Look.y, input.Look.x) * sensitivity;
        _eulerAngles.x = Mathf.Clamp(_eulerAngles.x, -90f, 90f);
        transform.eulerAngles = _eulerAngles;
    }

    public void UpdatePosition(Transform target)
    {
        transform.position = target.position;
    }
}
