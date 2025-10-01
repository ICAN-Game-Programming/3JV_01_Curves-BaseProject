using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public static Camera Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<Camera>();
        }
        else
        {
            Debug.LogWarning("Multiple CameraManagers found. Destroying extra script instance.");
            Destroy(this);
        }
    }
}
