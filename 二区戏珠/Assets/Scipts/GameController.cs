using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public 效果触发 效果触发;
    public spawn随机效果 spawn随机效果;
    public Player1 player1;
    public Player2 player2;
    private bool _isGamePaused = false;

    private void Awake()
    {
        if (Instance != null)
        {
           Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        _isGamePaused = true;
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        _isGamePaused = false;
        Time.timeScale = 1f;
    }

}
