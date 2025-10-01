using UnityEngine;

[DefaultExecutionOrder(-50)]
public class Player : MonoBehaviour
{
    private static Player _instance;

    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Player instance is null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}