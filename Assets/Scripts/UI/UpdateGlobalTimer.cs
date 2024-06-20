using UnityEngine;

public class UpdateGlobalTimer : MonoBehaviour
{
    [SerializeField] private UIManager _UIManager;

    private void FixedUpdate()
    {
        _UIManager.SetTimerInGame();
    }
}
