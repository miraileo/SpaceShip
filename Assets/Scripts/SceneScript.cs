using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void NextScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        NextScene(SceneManager.GetActiveScene().buildIndex);
    }
}
