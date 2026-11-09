using UnityEngine;

public class MoveMinhoco : MonoBehaviour
{
    public Transform Minhoco;
    public float speed = 5f;

    void Start()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Scoring"))
        {
           Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
        }

        Destroy(gameObject);
    }
}