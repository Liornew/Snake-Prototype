using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int intialSize = 5;
    public List<Color> _segmentColor = new List<Color>();
    public int bodySize = 5;

    private void Start()
    {
        resetState();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
    }
    private void FixedUpdate()
    {
        for (int i =  _segments.Count -1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3
        (
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        GameObject segmentGameObject = segment.gameObject;
        SpriteRenderer spriteRendererComponent = segmentGameObject.GetComponent<SpriteRenderer>();

        spriteRendererComponent.color = this._segmentColor[_segments.Count / bodySize];
        _segments.Add(segment);
    }

    private Color ColorGamut(int v1, int v2, int v3)
    {
        throw new NotImplementedException();
    }

    private void resetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.intialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        {
            if (other.tag == "Food")
            {
                Grow();
            }
            else if (other.tag == "Obstacle")
            {
                resetState();
            }
        } 
    }
}
