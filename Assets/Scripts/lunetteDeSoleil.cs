using UnityEngine;

public class lunetteDeSoleil : MonoBehaviour
{
    public GameObject borderObject;
    public bool borderActivate;
    public Material litMaterial;
    public Material unlitMaterial;

    void Update()
    {
        if (borderActivate == true)
        {
            borderObject.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().material = unlitMaterial;
        }
        else 
        {
            borderObject.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().material = litMaterial;
        }
    }
}
