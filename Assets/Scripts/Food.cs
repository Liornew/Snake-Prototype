using UnityEngine;
using System.Collections.Generic;

public class Food : MonoBehaviour
{
    public List<BoxCollider2D> gridAreas;
    private void Start()
    {
        RandomizePosition();
    }
    private void RandomizePosition()
    {
        Bounds bounds = this.gridAreas[Random.Range(0, gridAreas.Count - 1)].bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomizePosition();
        }

    }
}
