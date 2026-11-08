using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Collectible> coinList;

    private Finish endDoor;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collectible[] collectibles = FindObjectsByType<Collectible>();

        coinList = new List<Collectible>(collectibles);

        Debug.Log("There are " + coinList.Count + " coins in the level");

        endDoor = FindAnyObjectByType<Finish>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CoinCollected(Collectible _coin)
    {
        coinList.Remove(_coin);

        if (coinList.Count <= 0)
        {
            endDoor.lockObject.SetActive(false);
            endDoor.particleEffect.SetActive(true);
            endDoor.doorOpen = true;
            Debug.Log("All coins collected, door opened");
        }
    }

    public void WinGame()
    {
        AudioManager.Instance.PlayGameEndSound();
        UIManager.instance.winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
