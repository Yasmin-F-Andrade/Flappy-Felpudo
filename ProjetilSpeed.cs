using UnityEngine;

public class SpeedProjetil : MonoBehaviour
{
    public float speed = 6f;
    public float tempoVida = 5f;
    public int danoOvo = 1;

    void Start()
    {
        Destroy(gameObject, tempoVida);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }

        BossController boss = other.GetComponent<BossController>();
        if (boss != null)
        {
            boss.ReceberDanoBoss(danoOvo);
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("Obstacle"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.IncreaseScore();
            }
        }

        Destroy(gameObject);
    }
}