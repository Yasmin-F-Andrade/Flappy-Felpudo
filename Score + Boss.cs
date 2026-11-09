using UnityEngine;
using UnityEngine.UI;

public class PlacarSimples : MonoBehaviour
{
    private Text textoPlacar;

    void Start()
    {
        GameObject canvasObj = new GameObject("Canvas_Teste");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 32767;
        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        GameObject textoObj = new GameObject("Texto_Placar_Teste");
        textoObj.transform.SetParent(canvasObj.transform, false);

        textoPlacar = textoObj.AddComponent<Text>();
        textoPlacar.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        textoPlacar.fontSize = 200;
        textoPlacar.alignment = TextAnchor.MiddleCenter;
        textoPlacar.color = Color.white;

        RectTransform rect = textoObj.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 1f);
        rect.anchorMax = new Vector2(0.5f, 1f);
        rect.pivot = new Vector2(0.5f, 1f);
        rect.anchoredPosition = new Vector2(0f, -50f);
        rect.sizeDelta = new Vector2(400f, 100f);

        textoPlacar.text = "0";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.IncreaseScore();

                if (textoPlacar != null)
                {
                    textoPlacar.text = GameManager.Instance.Score.ToString();
                }

                Debug.Log("Ponto somado! Score total: " + GameManager.Instance.Score);
            }
            else
            {
                Debug.LogWarning("GameManager.Instance não foi encontrado na cena!");
            }
        }
    }
}