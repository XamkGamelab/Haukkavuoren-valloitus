using UnityEngine;

public class Finish : MonoBehaviour
{
    public bool doorOpen = false;

    public GameObject lockObject;

    public GameObject particleEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && doorOpen)
        {
            GameManager.instance.WinGame();
        }
        else
        {
            //Show get coin text
            Debug.Log("Go Get Coin");
        }
    }
}
