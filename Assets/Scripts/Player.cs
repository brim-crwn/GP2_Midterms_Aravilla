using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject GameScore;

    private void Start()
    {
        if (GameOverScreen != null)
        {
            GameOverScreen.SetActive(false);
        }
        if (GameScore != null)
        {
            GameScore.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Debug.Log("Player hit by enemy! Pausing game.");
        Time.timeScale = 0f;
        GameOverScreen.SetActive(true);
        GameScore.SetActive(false);

    }

}
