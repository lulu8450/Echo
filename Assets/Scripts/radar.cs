using UnityEngine;

public class Radar : MonoBehaviour
{
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
