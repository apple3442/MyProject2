using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalRenderer : MonoBehaviour
{
    private int _value = 0;

    [SerializeField]
    private Image _image = null;

    [SerializeField]
    private Sprite[] _sprites = new Sprite[5];

    public int Value
    {
        get { return _value; }
        set
        {
            _value = Mathf.Clamp(value, 0, _sprites.Length);
        }
    }

    private void Render()
    {
        if(0<=_value&&_value<_sprites.Length)
        {
            _image.sprite = _sprites[_value];
        }
    }
}
