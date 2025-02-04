using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX; 

    GamesceneManager gamesceneManager;

    private void Start()
    {
        gamesceneManager = FindFirstObjectByType<GamesceneManager>();
    }
    // FUNFACT
    /*Trong unity có một cơ chế, khi đó, nếu game có xử lý các sự kiện collider, ... 
        thì class như đây sẽ ko xử lý hàm Start mà sẽ xử lý hàm trigger =)))*/

    private void OnTriggerEnter(Collider other)
    {
        gamesceneManager.ReloadLevel();
        Instantiate(destroyVFX, transform.position, Quaternion.identity);
        // Debug.Log("Hit " + other.gameObject.name);
        Debug.Log($"Hit {other.gameObject.name}");
        Destroy(gameObject);

    }
}
