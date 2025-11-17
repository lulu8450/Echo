using UnityEngine;
using DG.Tweening;

public class Radar : MonoBehaviour
{
    public float radiusMin = 0;
    public float radiusMax = 5;
    public float scanDurration = 1;
    bool inRadar = false;

    void Start()
    {
        transform.localScale = Vector3.one * radiusMin;
    }
    public void UseRadar()
    {
        if (inRadar) return;
        inRadar = true;
        transform.localScale = Vector3.one * radiusMin;
        transform.DOScale(radiusMax,scanDurration).OnComplete(EndRadar);
    }

    private void EndRadar()
    {
        inRadar = false;
        transform.localScale = Vector3.one * radiusMin;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjectBorder"))
        {
            collision.GetComponent<lunetteDeSoleil>().borderActivate = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjectBorder"))
        {
            collision.GetComponent<lunetteDeSoleil>().borderActivate = false;
        }
    }
}
