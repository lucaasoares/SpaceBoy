using UnityEngine;

public class GameOverMusic : MonoBehaviour
{
    void Start()
    {
        MusicManager.instance.PlayGameOver();
    }
}