using UnityEngine;

public class Finish : MonoBehaviour
{
    public bool doorOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && doorOpen)
        {
            //Show you win text
            Debug.Log("You Win");
        }
        else
        {
            //Show get coin text
            Debug.Log("Go Get Coin");
        }
    }
}
