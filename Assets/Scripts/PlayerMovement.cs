using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Basic enum state machine for simplicity : 
    public enum MovementState
    {
        Normal,
        Dash
    }
    
    [Header("Movement")]
    [SerializeField] private float _normalSpeed = 6f;
    [SerializeField] private float _smoothingTime = 0.3f;

    [Header("Dash")]
    //...
    [SerializeField] private float _dashDistance = 4f;
    [SerializeField] private float _dashDuration = 0.5f;

    private Rigidbody _rb;
    private Vector3 _smoothVelocity = Vector3.zero;
    private MovementState _state = MovementState.Normal;
    private float _dashTimer;
    private Vector3 _startPosition;
    private Vector3 _targetPosition;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        switch (_state)
        {
            case MovementState.Normal:
                UpdateMove();
                break;
            case MovementState.Dash:
                UpdateDash();
                break;
        }
    }

    private void UpdateMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 desiredVelocity = Vector3.Normalize(new Vector3(h, 0f, v)) * _normalSpeed;
        _rb.linearVelocity = Vector3.SmoothDamp(_rb.linearVelocity, desiredVelocity, ref _smoothVelocity, _smoothingTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartDash();
        }
    }

    private void StartDash()
    {
        _state = MovementState.Dash;
        _rb.isKinematic = true;
        _dashTimer = 0f;
    }

    private void UpdateDash()
    {
        _dashTimer += Time.deltaTime;
        
        //➡️ todo dash based on curve :
        //...
        
        if (_dashTimer >= _dashDuration)
        {
            _rb.isKinematic = false;
            _state = MovementState.Normal;
        }
    }
}