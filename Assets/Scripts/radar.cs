using UnityEngine;
using DG.Tweening;

public class Radar : MonoBehaviour
{
    public float radiusMin = 0f; 
    public float radiusMax = 5f;
    public float scanDurration = 1f;

    void Start()
    {
        transform.localScale = Vector3.zero * radiusMin;
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
