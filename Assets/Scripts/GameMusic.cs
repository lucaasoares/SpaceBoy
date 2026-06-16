using UnityEngine;

public class GameMusic : MonoBehaviour
{
    void Start()
    {
        MusicManager.instance.PlayGame();
    }
}