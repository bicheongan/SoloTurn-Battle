using UnityEngine;

public class LookCamera : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    private void LateUpdate()
    {
        Look();
    }

    private void Look()
    {
        this.transform.rotation = _mainCamera.transform.rotation;
    }
}

