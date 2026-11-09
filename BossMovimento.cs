using UnityEngine;

public class BossController : MonoBehaviour
{
    public float velocidade = 3f;
    public float amplitude = 2.5f;

    public int vidaBoss = 8;

    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        float novaPosY = posicaoInicial.y + Mathf.Sin(Time.time * velocidade) * amplitude;
        transform.position = new Vector3(transform.position.x, novaPosY, transform.position.z);
    }

    public void ReceberDanoBoss(int dano)
    {
        vidaBoss -= dano;

        if (vidaBoss <= 0)
        {
            DestruirBoss();
        }
    }

    void DestruirBoss()
    {
        Debug.Log("Boss derrotado!");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.VencerJogo();
        }

        Destroy(gameObject);
    }
}