using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int birdsRemaining = 3;
    public GameObject birdPrefab;
    public Transform spawnPoint;
    public Trajectory trajectory;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnBird(); 
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.Log("You Win!");
        }
    }

    public void UseBird()
    {
        birdsRemaining--;

        if (birdsRemaining <= 0)
        {
            Debug.Log("No birds left!");
        }
    }

    public void BirdFinished(GameObject bird)
    {
        Destroy(bird); 

        if (birdsRemaining > 0)
        {
            SpawnBird();
        }
        else
        {
            Debug.Log("Game Over!");
        }
    }

    public void SpawnBird()
    {
        GameObject bird = Instantiate(birdPrefab, spawnPoint.position, Quaternion.identity);
        SoundManager.instance.PlaySound(SoundManager.instance.spawnSound);
        BirdLaunch birdScript = bird.GetComponent<BirdLaunch>();
        birdScript.trajectory = trajectory;
    }
}