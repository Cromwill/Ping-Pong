using System;
using UnityEngine;

public interface ISide
{
    void AnotherActionsSubscribe(Action<int> reduceAction);
}
