using UnityEngine;

public class OvoProjetil : MonoBehaviour
{
    public GameObject Projetil;
    public Transform DisparaOvo;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (Projetil != null && DisparaOvo != null)
            {

                Instantiate(Projetil, DisparaOvo.position, DisparaOvo.rotation);

                {
                }
            }
        }
    }
}