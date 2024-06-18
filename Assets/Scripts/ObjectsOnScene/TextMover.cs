using UnityEngine;

public class TextMover : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private Explorer explorer;
    [SerializeField] private float liftSpeed;

    private float timerClose = 0f;

    private void Update()
    {
        timer -= Time.deltaTime;
        timerClose += Time.deltaTime;

        if(timer <= 0)
        {
            Vector3 newPosition = transform.position;
            newPosition.y += liftSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
        if(timerClose >= 80f) 
        {
            explorer.LoadScene(0);
        }
    }
}
