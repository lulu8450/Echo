using UnityEngine;
using DG.Tweening;

public class Radar : MonoBehaviour
{
    public float radiusMin = 0f; 
    public float radiusMax = 5f;
    public float scanDurration = 1f;

    void Start()
    {
        // Utiliser Vector3.zero pour s'assurer que l'onde est invisible au début
        transform.localScale = Vector3.zero * radiusMin; 
        
        // Lancer l'animation dès l'apparition, si ce prefab est instancié par le joueur
        UseRadar(); 
    }
    public void UseRadar() 
    {
        transform.DOScale(radiusMax, scanDurration).OnComplete(EndRadar).SetEase(Ease.OutSine);
    }

    private void EndRadar()
    {
        transform.localScale = Vector3.one * radiusMin;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjectBorder"))
        {
            // Appeler la nouvelle fonction plus propre
            lunetteDeSoleil revealedObj = collision.GetComponent<lunetteDeSoleil>();
            if (revealedObj != null)
            {
                revealedObj.SetVisibility(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjectBorder"))
        {
            lunetteDeSoleil revealedObj = collision.GetComponent<lunetteDeSoleil>();
            if (revealedObj != null)
            {
                revealedObj.SetVisibility(false); 
            }
        }
    }
}
