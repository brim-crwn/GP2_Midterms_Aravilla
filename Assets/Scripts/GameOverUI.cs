using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
