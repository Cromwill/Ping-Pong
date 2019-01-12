using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PongV2;

public class Wall : MonoBehaviour
{
    [SerializeField] private Side _side;
    private Collider2D _col2D;

    #region trash
    //public float GetColliderRectY()
    //{
    //    if (_col2D == null)
    //    {
    //        _col2D = GetComponent<Collider2D>();
    //    }

    //    return _col2D.bounds.min.y;
    //}

    //public float GetColliderRectHight()
    //{
    //    if (_col2D == null)
    //    {
    //        _col2D = GetComponent<Collider2D>();
    //    }
    //    return _col2D.bounds.size.y;
    //}
    #endregion

    public void Losses()
    {
        _side.ChangeScore(0);
    }
}
