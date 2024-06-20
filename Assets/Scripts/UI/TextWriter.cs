using UnityEngine;

public class TextWriter : MonoBehaviour
{
    [SerializeField] private UIManager _UIManager;

    private void Start()
    {
        StartCoroutine(_UIManager.WriteText());
    }
}
