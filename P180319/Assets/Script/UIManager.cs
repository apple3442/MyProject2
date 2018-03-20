﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private GameObject _title = null;

    [SerializeField]
    private Button _startButton = null;

    [SerializeField]
    private Button _tipButton = null;


    public void StartButton ()
    {
        ShowTipButton();

        _title.SetActive(false);
        _startButton.gameObject.SetActive(false);
    }
	
	public void TipButton ()
    {
        ShowScore();
        Manager.Instance.isPlay = true;
        _tipButton.gameObject.SetActive(false);
    }

    private void ShowTipButton()
    {
        _tipButton.gameObject.SetActive(true);
    }

    private void ShowScore()
    {

    }
}