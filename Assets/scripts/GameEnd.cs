using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameObject final;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            final.SetActive(true);
    }
}
