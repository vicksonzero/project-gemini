using UnityEngine;
using UnityEngine.SceneManagement;

public class BGoToScene : MonoBehaviour
{
    public string nextSceneName;
    // Start is called before the first frame update
    public void Go()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
