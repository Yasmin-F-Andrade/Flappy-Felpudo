using UnityEngine;

public class GerenciadorBoss : MonoBehaviour
{
    public GameObject prefabBoss;
    public Transform BossSpawn;
    public int ScoreSpawn = 5;

    private GameObject bossInstanciado;
    public int vidaBoss { get; private set; } = 8;
    private bool bossAtivo = false;

    void Update()
    {
        if (!bossAtivo && GameManager.Instance != null)
        {
            if (GameManager.Instance.Score >= ScoreSpawn)
            {
                AtivarBoss();
            }
        }
    }

    void AtivarBoss()
    {
        bossAtivo = true;
        vidaBoss = 8;

        if (prefabBoss != null && BossSpawn != null)
        {
            bossInstanciado = Instantiate(prefabBoss, BossSpawn.position, BossSpawn.rotation);
        }
        else
        {
            return;
        }
        
    }
}
