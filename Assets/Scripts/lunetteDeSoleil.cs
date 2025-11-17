using UnityEngine;

public class lunetteDeSoleil : MonoBehaviour
{
    [Header("Référence Visuelle")]
    [SerializeField] private GameObject borderObject;
    [SerializeField] private Material litMaterial;
    [SerializeField] private Material unlitMaterial;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        // 1. Cacher la référence coûteuse
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        
        // S'assurer que l'objet commence invisible/non-révélé
        SetVisibility(false); 
    }
    public void SetVisibility(bool isVisible)
    {
        // Si borderObject est assigné, on l'active ou le désactive
        if (borderObject != null)
        {
            borderObject.SetActive(isVisible);
        }
        
        // On bascule le Material une seule fois
        if (isVisible)
        {
            spriteRenderer.material = unlitMaterial;
        }
        else 
        {
            spriteRenderer.material = litMaterial;
        }
    }
}
