using UnityEngine;

public class RemoveObject : MonoBehaviour
{
    public GameObject destroyObject;
    public GameObject disableObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy the destroyObject
        if (destroyObject != null)
        {
            Destroy(destroyObject);
        }

        // Disable the disableObject
        if (disableObject != null)
        {
            disableObject.SetActive(false);
        }
    }
}