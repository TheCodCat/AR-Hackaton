using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        StartCoroutine(Loader(name));
    }
    private IEnumerator Loader(string name)
    {
        SceneManager.LoadSceneAsync(name);
        yield return null;
    }
}
