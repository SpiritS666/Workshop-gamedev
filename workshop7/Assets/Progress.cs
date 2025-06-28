using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerInfo
{
    public int Score = 0;
}

public class Progress : MonoBehaviour
{
    public PlayerInfo PlayerInfo;
    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        PlayerInfo.Score += amount;

        if (PlayerInfo.Score >= 100)  
        {
            PlayerInfo.Score = 0;     
            SceneManager.LoadScene("MainLevel");  
        }
    }
}
