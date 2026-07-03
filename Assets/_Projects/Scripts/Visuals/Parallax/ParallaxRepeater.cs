using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(300)]
public class ParallaxRepeater : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private List<Transform> _tiles = new();

    [SerializeField] private float _tileObjectWidth = 19.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (_camera == null) _camera = Camera.main;

        if (_tiles.Count == 0) CollectChildTile();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        RepeatParallax();
    }

    private void CollectChildTile()
    {
        foreach (Transform child in transform) _tiles.Add(child);
    }

    private float GetCameraLeftEdge()
    {
        var cameraHalfWidth = _camera.orthographicSize * _camera.aspect;
        return _camera.transform.position.x - cameraHalfWidth;
    }

    private Transform GetLeftTile()
    {
        var leftTile = _tiles[0];
        for (var i = 0; i < _tiles.Count; i++)
            if (_tiles[i].transform.position.x < leftTile.position.x)
                leftTile = _tiles[i];

        return leftTile;
    }

    private Transform GetRightTile()
    {
        var rightTile = _tiles[0];
        for (var i = 0; i < _tiles.Count; i++)
            if (_tiles[i].transform.position.x > rightTile.position.x)
                rightTile = _tiles[i];

        return rightTile;
    }

    private void RepeatParallax()
    {
        if (_tiles.Count == 0)
            return;
        var leftTile = GetLeftTile();
        var rightTile = GetRightTile();

        var cameraLeftEdge = GetCameraLeftEdge();

        var leftmostTileRightEdge = leftTile.position.x + _tileObjectWidth / 2f;

        if (leftmostTileRightEdge < cameraLeftEdge)

        {
            var newLocalPosition = leftTile.localPosition;
            newLocalPosition.x = rightTile.localPosition.x + _tileObjectWidth;

            leftTile.localPosition = newLocalPosition;
        }
    }
}