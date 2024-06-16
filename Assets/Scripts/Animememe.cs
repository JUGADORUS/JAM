using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Animememe : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] CinemachineVirtualCamera camera;

    private void Start()
    {
        timer = 0f;
    }

    public IEnumerator Falling(Player player)
    { 
        gameObject.SetActive(true);
        camera.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = 0;


        while (timer < 4f)
        {
            timer += Time.deltaTime;
            Vector3 offset = new Vector3(0, 0, 10);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
            yield return null;
        }

        gameObject.SetActive(false);
        camera.GetCinemachineComponent<CinemachineTransposer>().m_YDamping = 1;
    }
}
