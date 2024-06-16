using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class RespawnShape : MonoBehaviour
{
    public SOPlayer player;
    private Player Current;
    private Transform Copy;
    [SerializeField] private float distance;
    private void Start()
    {
        SpawnInit(player.modelPlayers[player.indexGeneralShape], Vector3.zero);
    }
    private void Update()
    {
        ChangeShape();
        Current?.OnUpdate();
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
    public void Clone()
    {
        if (Copy != null)
        {
            Destroy(Copy.gameObject);
        }
        float wight = Current.gameObject.transform.localScale.x * 2;
        if(CheckCollision(new Vector3(Current.transform.position.x + wight + distance, Current.transform.position.y, Current.transform.position.z)))
        {
            return;
        }
        Player copy = Instantiate(Current.modelPlayer.prefab, new Vector3(Current.transform.position.x + wight + distance, Current.transform.position.y, Current.transform.position.z), Quaternion.identity);
        Copy = copy.transform;
        Destroy(copy);
    }
    private void CheckNotInit(ModelPlayer model)
    {
        if (Current == null || Current.GetType().Equals(model.prefab.GetType()) || CheckCollision(Current.transform.position))
        {
            return;
        }
        Vector3 pos = Vector3.zero;
        if (Current != null)
        {
            pos = Current.transform.position;
            Destroy(Current.gameObject);
        }
        SpawnInit(model, pos);
    }
    public bool CheckCollision(Vector3 centre)
    {
        Vector3 extance = centre;
        extance.x += centre.x + 1f;
        Collider[] colliders = Physics.OverlapBox(centre, Current.transform.localScale / 2, Quaternion.identity);
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
    void OnDrawGizmos()
    {
        if (Current != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(Current.transform.position, Current.transform.localScale);
        }
    }
    public void SpawnInit(ModelPlayer model, Vector3 pos)
    {
        Current = Instantiate(model.prefab, pos, Quaternion.identity);
        Current.Init(model, this);
    }
}
