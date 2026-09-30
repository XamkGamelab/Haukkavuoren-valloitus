using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Finish finishLine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //play sound
            finishLine.doorOpen = true;
            Destroy(gameObject);
        }
    }
}
