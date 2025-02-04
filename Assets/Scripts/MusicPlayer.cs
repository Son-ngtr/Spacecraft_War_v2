using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    private void Start()
    {
        int numOfMusicManager = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;

        if (numOfMusicManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
