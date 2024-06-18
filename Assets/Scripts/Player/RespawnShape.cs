using UnityEngine;
using Cinemachine;

public class RespawnShape : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private Material _material;
    [SerializeField] private GameObject _jumpEffect;
    [SerializeField] private float _distance;

    private Player _current;
    private Transform _copy;
    private Vector3 _velocity;
    public SOPlayer player;

    private void Start()
    {
        SpawnInit(player.modelPlayers[player.indexGeneralShape], transform.position);
    }

    private void Update()
    {
        ChangeShape();
        _current?.OnUpdate();
    }

    public void OnDrawGizmos()
    {
        if (_current != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_current.transform.position, _current.transform.localScale);
        }
    }

    private void ChangeShape()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CheckNotInit(player.modelPlayers[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CheckNotInit(player.modelPlayers[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CheckNotInit(player.modelPlayers[2]);
        }
    }

    private void CheckNotInit(ModelPlayer model)
    {
        if (_current == null || _current.GetType().Equals(model.prefab.GetType()) || CheckCollision(_current.transform.position))
        {
            return;
        }

        Vector3 pos = transform.position;

        if (_current != null)
        {
            pos = _current.transform.position;
            _velocity = _current.GetComponent<Rigidbody>().velocity;
            Destroy(_current.gameObject);
        }

        SpawnInit(model, pos);

    }

    public void Clone()
    {
        if (_copy != null)
        {
            Destroy(_copy.gameObject);
        }

        float wight = _current.gameObject.transform.localScale.x * 2;

        if (CheckCollision(new Vector3(_current.transform.position.x + wight + _distance, _current.transform.position.y, _current.transform.position.z)))
        {
            return;
        }

        Player copy = Instantiate(_current.modelPlayer.prefab, new Vector3(_current.transform.position.x + wight + _distance, _current.transform.position.y, _current.transform.position.z), Quaternion.identity);
        copy.mesh.material = _material;
        _copy = copy.transform;
        Destroy(copy);
    }

    public bool CheckCollision(Vector3 centre)
    {
        Vector3 extance = centre;
        extance.x += centre.x + 1f;
        Collider[] colliders = Physics.OverlapBox(centre, _current.transform.localScale, Quaternion.identity);
        int count = 0;

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent<Obstacle>(out Obstacle obstacle))
            {
                Debug.Log($"{colliders[i].name} �����");
                count++;
            }
        }

        return count > 1;
    }

    public void SpawnInit(ModelPlayer model, Vector3 pos)
    {
        AudioManager.Instance.Sound.PlayOneShot(AudioManager.Instance.SpawnClip);
        _current = Instantiate(model.prefab, pos, Quaternion.identity);
        _current.GetComponent<Rigidbody>().velocity = _velocity;
        _current.Init(model, this, _jumpEffect);
        _camera.Follow = _current.transform;
    }
}
