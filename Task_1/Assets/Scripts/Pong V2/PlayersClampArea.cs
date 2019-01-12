using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersClampArea : MonoBehaviour
{
    public Vector2 RectUpperPoint;
    public Vector2 RectDownerPoint;

    public float Height => RectUpperPoint.y - RectDownerPoint.y;
    public float Width => RectUpperPoint.x - RectDownerPoint.x;
    public float yMin => RectDownerPoint.y;
    public float yMax => RectUpperPoint.y;


    public Rect GetRect()
    {
        Vector2 difference = RectUpperPoint - RectDownerPoint;
        return new Rect(RectUpperPoint, new Vector2(difference.x, difference.y));
    }


}
