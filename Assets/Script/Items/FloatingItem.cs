using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public float floatAmplitude = 0f;
    public float floatSpeed = 0f;
    public float rotationSpeed = 0f;

    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Floating up and down
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Rotating
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
