using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyShipVfx;
    [Header ("ENEMY HEALTH")]
    [SerializeField] int hitPoints = 3;

    [SerializeField] int scoreValue = 10;

    // Progress Scoreboard System
    Scoreboard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        DestroyEnemy();
    }

    private void DestroyEnemy()
    {
        hitPoints -= 1;
        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(destroyShipVfx, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
