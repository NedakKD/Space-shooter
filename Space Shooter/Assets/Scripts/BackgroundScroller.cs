using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private float distance;

    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        startPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float offset = Mathf.Repeat(0, distance) * Time.time * speed;
        transform.position = startPosition + (Vector3.back * offset);
    }
}
