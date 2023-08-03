using System;
using UnityEngine;

public class Borders
{
    public float X { private set; get; }
    public float Y { private set; get; }

    public Borders(float x,float y)
    {
        X = x;
        Y = y;
    }
}

/// <summary>
/// Get and send all characters info about game borders
/// </summary>
public class GroundBorders : MonoBehaviour
{
    [SerializeField] private SpriteRenderer groundSpriteRenderer;

    private float _xBorder, _yBorder;

    #region Enents

    private static event Action<Borders> SendGroundBorders;

    public static void SubscribeToSendGroundBorders(Action<Borders> method)
    {
        SendGroundBorders += method;
    }
    
    public static void UnsubscribeFromSendGroundBorders(Action<Borders> method)
    {
        SendGroundBorders -= method;
    }
    
    #endregion
    private void Awake()
    {
        var borders = groundSpriteRenderer.bounds.max;
        _xBorder = borders.x;
        _yBorder = borders.y;
    }

    private void Start()
    {
        SendGroundBorders?.Invoke(new Borders(_xBorder,_yBorder));
    }
}
