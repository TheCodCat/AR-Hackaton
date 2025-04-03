using UnityEngine;

public class RayInteractor : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Debug.Log("ASDASD");
                if (hitInfo.collider.TryGetComponent(out IInteract component))
                {
                    component.Interact();
                }
            }
        }
    }
}
