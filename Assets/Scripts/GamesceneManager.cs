using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesceneManager : MonoBehaviour
{
    [SerializeField] float timeWaiting = 1.2f;

        public void ReloadLevel()
    {
        StartCoroutine(ReloadWhenTrigger());
    }

    IEnumerator ReloadWhenTrigger()
    {
        yield return new WaitForSeconds(timeWaiting);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Reload Level");
        SceneManager.LoadScene(currentSceneIndex);
    }
}
