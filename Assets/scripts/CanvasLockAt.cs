using UnityEngine;

public class CanvasLockAt : MonoBehaviour
{
    private Camera _camera;

    private void OnEnable()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        transform.LookAt(_camera.transform);
    }
}
