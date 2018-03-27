using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    [SerializeField]
    private Bird _bird = null;
    [SerializeField]
    private Ground _ground = null;
    [SerializeField]
    private Pipe _pipe = null;

    [SerializeField]
    private float _speed = 0.001f;
    [SerializeField]
    private float _createTime = 1.0f;
    [SerializeField]
    private float _pipeRandomHeight = 0.4f;
    [SerializeField]
    private float _pipeRandomPositionY = 0.5f;

    private float _currentTime = 0.0f;

    private List<Pipe> _pipeList = new List<Pipe>();

    private bool _bPlay = false;
    private int _score = 0;

    public float Speed { get { return _speed; } }
    public bool isPlay { get { return _bPlay; } set {_bPlay = value;} }


    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _bPlay = false;
        _score = 0;
        _currentTime = 0.0f;
        _bird.transform.position=
    }

    // Update is called once per frame
    void Update()
    {
        _bird.FreezePositionY(!_bPlay);
        if (_bPlay)
        {
            _currentTime += Time.deltaTime;
            if (_createTime < _currentTime)
            {
                _currentTime = 0;

                _pipe.SetHeight(Random.Range(0.0f, _pipeRandomHeight));
                _pipe.SetPositionY(Random.Range(0.0f, _pipeRandomPositionY));
                _pipeList.Add(GameObject.Instantiate(_pipe));
            }
            _bird.GameUpdate();
            _ground.GameUpdate();
            _pipeList.ForEach((x) =>
            {
                x.GameUpdate();
                if (x.isNeedInvokeScoreCheck(_bird.transform.position))
                {
                    InvokeScore();
                }
            });
        }
    }

    public void Remove(Pipe target)
    {
        _pipeList.Remove(target);
        Destroy(target.gameObject);
    }

    private void InvokeScore()
    {
        _score++;
        UIManager.Instance.Score = _score;
        Debug.Log(_score);
    }
}
