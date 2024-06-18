using System.Collections;
using UnityEngine;
using Cinemachine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private float _videoLength;
    [SerializeField] private CinemachineVirtualCamera _camera;

    private float _timer;

    private void Start()
    {
        _timer = 0f;
    }

    public IEnumerator Falling(Player player)
    { 
        gameObject.SetActive(true);
        _camera.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = 0;


        while (_timer < _videoLength)
        {
            _timer += Time.deltaTime;
            Vector3 offset = new Vector3(0, 0, 10);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
            yield return null;
        }

        gameObject.SetActive(false);
        _camera.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = 1;
    }
}
