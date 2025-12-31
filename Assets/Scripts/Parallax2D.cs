using UnityEngine;

public class Parallax2D : MonoBehaviour
{

	float startX;
    float length;

    Transform cam;

    [Range(0f, 1f)]
    [SerializeField] float parallaxEffectSpeed = 0.5f;

    void Start()
    {
        cam = Camera.main.transform;
        startX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void LateUpdate()
    {
        // Parallax movement
        float parallaxX = cam.position.x * parallaxEffectSpeed;
        transform.position = new Vector3(startX + parallaxX, transform.position.y, transform.position.z);

        // Infinite scrolling
        float temp = cam.position.x * (1 - parallaxEffectSpeed);

        if (temp > startX + length)
        {
            startX += length;
        }
        else if (temp < startX - length)
        {
            startX -= length;
        }
    }
}
