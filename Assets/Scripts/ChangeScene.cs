using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Scene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
