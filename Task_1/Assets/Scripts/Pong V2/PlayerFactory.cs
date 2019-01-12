using UnityEngine;
using System.Collections;

namespace PongV2
{
    class PlayerFactory
    {
        private Side _side;
        private GameObject _prototype;
        static int PlayersCounter = 0;

        public PlayerFactory(Side side, GameObject prototype)
        {
            _side = side;
            _prototype = prototype;
        }

        public void CreatePlayers()
        {
            for (int i = 0; i < Side.PlayersCount; i++)
            {
                GameObject playerObject = Side.PlayersCount == 1 ? CreateTwo() : CreateFour(i);
                IPlayer player = playerObject.GetComponent<IPlayer>();
                IAvatar avatar = playerObject.GetComponent<IAvatar>();
                player.Avatar = avatar;
                PlayersCounter++;
                player.ID = PlayersCounter;
                _side.AddPlayer(player);
            }
        }

        private GameObject CreateTwo()
        {
            GameObject player = Object.Instantiate(_prototype, _side.transform);
            //PlayersCounter++;
            player.transform.position = new Vector3(_side.transform.position.x, _side.transform.position.y);
            return player;
        }

        private GameObject CreateFour(int index)
        {
            int yDir = index % 2 == 0 ? 1 : -1;
            GameObject player = Object.Instantiate(_prototype, _side.transform);
            player.transform.position = new Vector3(_side.transform.position.x, _side.transform.position.y + (2 * yDir));
            return player;
        }
    }
}
