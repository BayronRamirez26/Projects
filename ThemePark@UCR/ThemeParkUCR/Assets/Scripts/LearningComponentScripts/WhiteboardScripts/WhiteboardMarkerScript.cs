using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WhiteboardMarkerScript : MonoBehaviour
{

    [SerializeField]
    private Transform tip;
    [SerializeField]
    private int penSize = 5;
    private Color[] _colors;
    private float _tipHeight;
    private Renderer _renderer;
    private RaycastHit _touch;
    private Whiteboard _whiteboard;
    private Vector2 _touchPosition, _lastTouchPosition;
    private bool _touchLastFrame;
    private Quaternion _lastTouchRotation;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = tip.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, penSize * penSize).ToArray();
        _tipHeight = tip.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Draw();    
    }

    private void Draw()
    {
        if(Physics.Raycast(tip.position, transform.up, out _touch, _tipHeight))
        {
            if (_touch.transform.CompareTag("Whiteboard"))
            {
                if(_whiteboard == null)
                {
                    _whiteboard = _touch.transform.GetComponent<Whiteboard>();
                }
                _touchPosition = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);
                var x = (int)(_touchPosition.x * _whiteboard.textureSize.x - (penSize / 2));
                var y = (int)(_touchPosition.y * _whiteboard.textureSize.y - (penSize / 2));

                if(x < 0 || x > _whiteboard.textureSize.x || y < 0 || y > _whiteboard.textureSize.y)
                {
                    return;
                }
                if (_touchLastFrame)
                {

                    _whiteboard.texture.SetPixels(x, y, penSize, penSize, _colors);
                    for (float i = 0.01f; i < 1.00f; i += 0.03f)
                    {
                        var lerpX = (int) Mathf.Lerp(_lastTouchPosition.x, x, i);
                        var lerpY = (int) Mathf.Lerp(_lastTouchPosition.y, y, i);
                        _whiteboard.texture.SetPixels(lerpX, lerpY, penSize, penSize, _colors);
                    }
                    transform.rotation = _lastTouchRotation;
                    _whiteboard.texture.Apply();
                }
                _lastTouchPosition = new Vector2(x, y);
                _lastTouchRotation = transform.rotation;
                _touchLastFrame = true;
                return;
            }
        }
        _whiteboard = null;
        _touchLastFrame = false;
    }
}
