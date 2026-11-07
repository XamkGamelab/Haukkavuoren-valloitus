using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject particle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //play sound
            Instantiate(particle, transform.position, Quaternion.identity);
            GameManager.instance.CoinCollected(this);
            Destroy(gameObject);
        }
    }
}
