using UnityEngine;
using Assets.Scripts.Pong.Interface;

namespace PongV2
{
    public class KeyboardPlayer : MonoBehaviour, IPlayer
    {
        private KeyController _keyController;
        private Rigidbody2D _selfRigidbody2D;
        private int _id;
        private IAvatar _avatar;

        public IAvatar Avatar
        {
            get
            {
                return _avatar;
            }
            set
            {
                _avatar = value;
            }
        }
        public KeyController KeyController
        {
            get
            {
                return _keyController;
            }

            set
            {
                _keyController = value;
            }
        }
        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        private void Start()
        {
            _selfRigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKey(_keyController.MoveUp))
            {
                _avatar.MoveUp();
            }
            if (Input.GetKey(_keyController.MoveDown))
            {
                _avatar.MoveDown();
            }

            if (Input.GetKeyDown(_keyController.UseItem))
            {
                Debug.Log("UseItem");
            }

            if (Input.GetKeyDown(_keyController.SelectShopLeft))
            {
                Debug.Log("SelectShopLeft");
            }

            if (Input.GetKeyDown(_keyController.SelectShopRight))
            {
                Debug.Log("SelectShopRight");
            }

            if (Input.GetKeyDown(_keyController.Buy))
            {
                Debug.Log("Buy");
            }

            _selfRigidbody2D.velocity = Vector2.zero;
        }
    }
}