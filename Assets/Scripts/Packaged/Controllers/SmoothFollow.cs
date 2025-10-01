using UnityEngine;

[ExecuteInEditMode]
public class SmoothFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothTime = 0.3F;
    [SerializeField] private float _depth;
    [SerializeField] private float _angle;

    private Vector3 _velocity = Vector3.zero;

    private void Update()
    {
        if (Application.isEditor && !Application.isPlaying && _target != null)
        {
            Quaternion rotation = Quaternion.AngleAxis(_angle, Vector3.right);
            Vector3 offset = rotation * (Vector3.up * _depth);
            transform.position = _target.position + offset;
            transform.LookAt(_target.position);
        }
    }

    private void FixedUpdate()
    {
        Quaternion rotation = Quaternion.AngleAxis(_angle, Vector3.right);
        Vector3 targetPosition = _target.position + rotation * (Vector3.up * _depth);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
    }
}