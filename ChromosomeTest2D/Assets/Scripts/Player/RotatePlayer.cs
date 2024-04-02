using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    private Vector3 pos;
    private Camera main;

    void Start()
    {
        main = FindAnyObjectByType<Camera>();
    }

    void Update()
    {
        Flip();
        pos = main.WorldToScreenPoint(transform.position);
    }

    void Flip()
    {
        if (Input.mousePosition.x < pos.x)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (Input.mousePosition.x > pos.x)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
