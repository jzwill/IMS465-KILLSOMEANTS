using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

public static LevelManager main;

public Transform startingPoint;
public Transform[] path;

public int currency;
public int playerLives;

private void Awake() {
    main = this;
}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currency = 100;
        playerLives = 80;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLives <= 0) {
            SceneManager.LoadScene(2);
        }
    }

    public void IncreaseCurrency(int amount) {
        currency += amount;
    }

    public void DecreaseLives(int amount) {
        playerLives -= amount;
    }

    public bool SpendCurrency(int amount) {
        if (amount <= currency){
            //buy
            currency -= amount;
            return true;
        } else {
            Debug.Log("too poor");
            return false;
        }
    }
}
