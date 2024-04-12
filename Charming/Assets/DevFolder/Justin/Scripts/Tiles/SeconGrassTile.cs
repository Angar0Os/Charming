using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeconGrassTile : Tile
{
    [SerializeField] private Color baseColor, offsetColor;
    public override void Init(int x, int y, GridManager gridMgr)
    {
        base.Init(x, y, gridMgr);

        var isOffset = (x + y) % 2 == 1;
        _renderer.color = isOffset ? offsetColor : baseColor;
    }
}
