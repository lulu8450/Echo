using UnityEngine;

public class changeRoom : MonoBehaviour
{
    public Transform spawnpoint;
    public Camera cam;
    public int camPos;
    public bool changeCamRoom;
    public bool isExit;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !isExit)
        {
            collision.transform.position = spawnpoint.position;
            if(changeCamRoom)
            {
                cam.transform.position = new Vector3(0,camPos,0);
            }
        }
        if(collision.CompareTag("Player") && isExit)
        {
            Debug.Log("tu quitte la zone");
        }
    }
}
