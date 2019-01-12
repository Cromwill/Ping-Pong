using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Assets.Scripts.Pong.Interface
{
    interface IItemsShop
    {
        void SelectRight(GameObject item);
        void SelectLeft(GameObject item);
        void Buy();

    }
}
