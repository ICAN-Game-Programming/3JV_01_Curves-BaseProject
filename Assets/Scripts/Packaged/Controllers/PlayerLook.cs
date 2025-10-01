using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera mainCamera; 

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Default")))
        {
            Vector3 lookPoint = hit.point;
            lookPoint.y = transform.position.y;
            transform.LookAt(lookPoint);
        }
    }
}
