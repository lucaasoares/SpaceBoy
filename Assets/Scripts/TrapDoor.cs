using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    public void Open()
    {
        GetComponent<BoxCollider2D>().enabled = false;

        Destroy(gameObject, 1f);
    }
}