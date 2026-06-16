using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    void Start()
    {
        MusicManager.instance.PlayMenu();
    }
}