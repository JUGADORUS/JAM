using UnityEngine;

public class UpdateScoreMenu : MonoBehaviour
{
    [SerializeField] private UIManager _UIManager;

    private void Start()
    {
        _UIManager.SetTimerInMenu();
    }
}
