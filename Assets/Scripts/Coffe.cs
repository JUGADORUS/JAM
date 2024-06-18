using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    [SerializeField] private float _effectTime = 5f;
    [SerializeField] private float _dissappearingTime = 1f;
    [SerializeField] private float _speedOfAnim = 1f;

    [SerializeField] private GameObject BuffEffect;
    private GameObject buff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player)) // .gameObject.TryGetComponent(out Mover mover))
        {
            if (buff == null)
            {
                buff = Instantiate(BuffEffect, player.transform.position, Quaternion.identity);
            }
            AudioManager.Instance.Sound.PlayOneShot(AudioManager.Instance.TakeCoffeClip);
            buff.transform.SetParent(player.transform);
            StartCoroutine(SetRotation(player));
            StartCoroutine(DissappearingProcess());
            StartCoroutine(CoffeeEffect(player));
        }
    }

    private IEnumerator SetRotation(Player player)
    {
        while(buff != null)
        {
            Quaternion rotation = player.transform.rotation;
            rotation.z = -rotation.z;
            buff.transform.localRotation =  rotation;
            yield return null;
        }

        buff = null;
    }

    private IEnumerator CoffeeEffect(Player player)
    {
        buff.transform.localRotation = Quaternion.Euler(0, 0, 0);
        player.modelPlayer.speed += 2f;
        player.modelPlayer.jumpForce += 3f;

        yield return new WaitForSeconds(_effectTime);
        player.modelPlayer.speed -= 2f;
        player.modelPlayer.jumpForce -= 3f;
        transform.localScale = Vector3.one;
        Destroy(buff);
    }

    private IEnumerator DissappearingProcess() //оепедекюрэ
    {
        float i = 0f;
        float rate = (1f / _dissappearingTime);

        while (i < 1f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, i);
            yield return null;
        }
    }
}

