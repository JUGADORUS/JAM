using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField] private Transform _pointOne;
    [SerializeField] private Transform _pointTwo;
    [SerializeField] private float _speed;

    private Transform _target;

    private void Start()
    {
        transform.position = _pointOne.position;
        SetTarget(_pointTwo);
    }

    private void FixedUpdate()
    {
        MoveToTarget(_target);
    }

    private void MoveToTarget(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed);
        Vector3 direction = target.position - transform.position;

        if (Vector3.Distance(transform.position, _target.position) < 1f && _target == _pointTwo)
        {
            _target = _pointOne;
        }
        else if (Vector3.Distance(transform.position, _target.position) < 1f && _target == _pointOne)
        {
            _target = _pointTwo;
        }
    }

    private void SetTarget(Transform target)
    {
        _target = target;
    }
}
