using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneManager : MonoBehaviour
{
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
