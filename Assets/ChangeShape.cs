using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShape : MonoBehaviour
{
    [SerializeField] public GameObject Triangle;
    [SerializeField] public GameObject Parallelepiped;
    [SerializeField] public GameObject Sphere;

    private void Start()
    {
        Sphere.SetActive(true);
        Triangle.SetActive(false);
        Parallelepiped.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Triangle.SetActive(false);
            Parallelepiped.SetActive(false);
            Sphere.SetActive(true);
            Sphere.transform.position = transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Triangle.SetActive(false);
            Sphere.SetActive(false);
            Parallelepiped.SetActive(true);
            Parallelepiped.transform.position = transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Sphere.SetActive(false);
            Parallelepiped.SetActive(false);
            Triangle.SetActive(true);
            Triangle.transform.position = transform.position;
        }
    }
}
