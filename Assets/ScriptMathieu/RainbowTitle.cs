using TMPro;
using UnityEngine;

public class RainbowTitle : MonoBehaviour
{
    [Header("Composant Texte")]
    [Tooltip("Le composant Text ou TextMeshPro du titre")]
    public TextMeshProUGUI tmpText; // Pour TextMeshPro
    public UnityEngine.UI.Text uiText; // Pour UI Text classique

    [Header("Paramètres de l'animation")]
    [Tooltip("Vitesse de changement de couleur (plus élevé = plus rapide)")]
    [Range(0.1f, 5f)]
    public float speed = 1f;

    [Tooltip("Saturation de la couleur (0-1)")]
    [Range(0f, 1f)]
    public float saturation = 1f;

    [Tooltip("Luminosité de la couleur (0-1)")]
    [Range(0f, 1f)]
    public float brightness = 1f;

    private float hue = 0f;

    void Start()
    {
        // Vérifier qu'au moins un composant texte est assigné
        if (tmpText == null && uiText == null)
        {
            Debug.LogWarning("Aucun composant texte assigné! Veuillez assigner tmpText ou uiText dans l'inspecteur.");
        }
    }

    void Update()
    {
        // Incrémenter la teinte (hue) pour créer l'effet arc-en-ciel
        hue += speed * Time.deltaTime * 0.1f;

        // Garder la valeur entre 0 et 1
        if (hue > 1f)
        {
            hue -= 1f;
        }

        // Convertir HSV en RGB
        Color rainbowColor = Color.HSVToRGB(hue, saturation, brightness);

        // Appliquer la couleur au composant texte approprié
        if (tmpText != null)
        {
            tmpText.color = rainbowColor;
        }

        if (uiText != null)
        {
            uiText.color = rainbowColor;
        }
    }
}
