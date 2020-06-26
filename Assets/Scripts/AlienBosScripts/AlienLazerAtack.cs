using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLazerAtack : MonoBehaviour
{

    private int i;
    private int _xPos;
    private int _yPos;
    private float _xEndPos;
    private float _yEndPos;
    private Rigidbody2D _lazerRigidbody;
    public LineRenderer lineRenderer;
    public bool _isCanLine;
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    private Vector3[] positions;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        Invoke("SpawnNextLazer", 1);
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = 2;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;
    }

    private void SpawnNextLazer()
    {
        _xPos = Random.Range(-2, 3);
        _yPos = Random.Range(-4, 5);
        Instantiate(gameObject, new Vector2(_xPos, _yPos), Quaternion.identity);
        _isCanLine = true;
    }

    private void SpawnLazer()
    {
        lineRenderer.SetPosition(0, transform.position);
    }

    private void Update()
    {
        if (_isCanLine)
        {
            SpawnLazer();
            lineRenderer.positionCount++;
            _xEndPos = Mathf.MoveTowards(transform.position.x, _xPos, Time.deltaTime * 2f);
            _yEndPos = Mathf.MoveTowards(transform.position.y, _yPos, Time.deltaTime * 2f);
            lineRenderer.SetPosition(i, new Vector2(_xEndPos, _yEndPos));
            i++;


        }
    }

}
