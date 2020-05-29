using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 100;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //CameraPos
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

            transform.position = player.transform.position; // Move focal point with player
        }
    }
}