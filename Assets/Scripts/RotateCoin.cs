using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public float rotationSpeed = 7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0));
    }
}
