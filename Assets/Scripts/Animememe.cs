using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animememe : MonoBehaviour
{
    [SerializeField] float timer;

    private void Start()
    {
        timer = 0f;
    }

    public IEnumerator Falling(Player player)
    { 
        gameObject.SetActive(true);

        while (timer < 8f)
        {
            Debug.Log("123");
            timer += Time.deltaTime;
            Vector3 offset = new Vector3(0, 0, 10);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
            /*Transform positionOfTV = player.transform;
            positionOfTV.position += offset;
            gameObject.transform.position = positionOfTV.position;*/
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
