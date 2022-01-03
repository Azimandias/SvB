using UnityEngine;

public class Game : MonoBehaviour
{
    public Movement Movement;
    public GameObject LosePanel;
    public Score scoreScript;
    public enum State
    {
        Playing,
        Loss,
    }

    public State CurrentState { get; private set; }

    public void OnSnakeDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Movement.enabled = false;
        Debug.Log("Game Over!");
        LosePanel.SetActive(true);        
    }
}
