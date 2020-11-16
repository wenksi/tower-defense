﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITowerDirection : MonoBehaviour, IArrowsInputController
{

    public event Action HandleLeft = delegate { };
    public event Action HandleRight = delegate { };
    public event Action HandleUp = delegate { };
    public event Action HandleDown = delegate { };

    [SerializeField] Button upButton;
    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;
    [SerializeField] Button downButton;

    private Button selected;

    private EconomyController _ec;

    public void OnEnable()
    {
        select(upButton);
        upButton.onClick.AddListener(() => HandleUp()) ;
        downButton.onClick.AddListener(() => HandleDown());
        leftButton.onClick.AddListener(() => HandleLeft());
        rightButton.onClick.AddListener(() => HandleRight());

        EconomyController.DirectionSelected += HighlightSelected;
    }

    public void OnDisable()
    {
        EconomyController.DirectionSelected -= HighlightSelected;
    }

    public void HighlightSelected(int direction)
    {
        Debug.Log("highlight selected");
        if (direction == 0)
        {  
            select(upButton);
            Debug.Log("highlight up");
        }
        else if (direction == 90)
        {
            select(rightButton);
            Debug.Log("highlight right");

        }
        else if (direction == 180)
        {
            select(downButton);
            Debug.Log("highlight down");

        }
        else
        {
            select(leftButton);
            Debug.Log("highlight left");
        }
    }

    private void highlight()
    {
        var colors = this.selected.colors;
        colors.normalColor = Color.red;
        colors.selectedColor = Color.red;
        this.selected.colors = colors;
    }

    private void unHighlight(Button button)
    {
        var colors = button.colors;
        colors.normalColor = Color.white;
        colors.pressedColor = Color.white; 

        button.colors = colors;
    }

    private void select(Button select)
    {
        var previous = selected;
        this.selected = select;
        if(previous != null)
        {
            unHighlight(previous);
        }

        //select.Select();
        highlight();
    }
}