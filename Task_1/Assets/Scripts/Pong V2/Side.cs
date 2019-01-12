using System;
using System.Collections.Generic;
using UnityEngine;

namespace PongV2
{
    public class Side : MonoBehaviour, ISide
    {
        public GameObject PlayerPrototype;
        public GameObject Wall;
        public static int PlayersCount = 1;


        [SerializeField] private KeyController[] _keyControllers;
        [SerializeField] private ScoreDrawer _scoreDrawer;
        [SerializeField] private GameObject _anotherSide;
        private List<IPlayer> Players = new List<IPlayer>();
        private Transform _selfTransform;
        private DirectionSide _sideDirection;
        private Score _selfScore;
        private ISide _opponent;

        private void OnEnable()
        {
            _selfScore = new Score();
            _opponent = _anotherSide.GetComponent<ISide>();

            _selfScore.OnScorreAdd += _scoreDrawer.ChangeScore;
            _selfScore.OnScorreReduce += _scoreDrawer.ChangeScore;
        }

        private void OnDisable()
        {
            _selfScore.OnScorreAdd -= _scoreDrawer.ChangeScore;
            _selfScore.OnScorreReduce -= _scoreDrawer.ChangeScore;
        }

        private void Start()
        {
            _selfTransform = GetComponent<Transform>();
            SetSideDirection();
            SetSidePosition(2);
            PlayerFactory factory = new PlayerFactory(this, PlayerPrototype);
            factory.CreatePlayers();
            _opponent.AnotherActionsSubscribe(_selfScore.AddScorre);
        }

        public void ChangeScore(int value)
        {
            _selfScore.ReduceScorre(0);
        }

        public void AnotherActionsSubscribe(Action<int> reduceAction)
        {
            _selfScore.OnScorreReduce += reduceAction;
        }

        public void AddPlayer(IPlayer player)
        {
            Players.Add(player);
            
            for(int i = 0; i < Players.Count; i++)
            {
                player.KeyController = _keyControllers[i];
            }
        }

        private void SetSideDirection()
        {
            _sideDirection = _selfTransform.position.x < 0 ? DirectionSide.right : DirectionSide.left;
        }

        private DirectionSide GetSideDirection()
        {
            return _sideDirection;
        }

        private void SetSidePosition(int indent)
        {
            Vector2 alignment = Wall.GetComponent<Transform>().position;
            _selfTransform.position = new Vector2(alignment.x + (indent * -(int)_sideDirection), alignment.y);
        }


    }

    public interface IPlayer
    {
        int ID { get; set; }
        IAvatar Avatar { get; set; }
        KeyController KeyController { get; set; }
    }

    public interface IAvatar
    {
        Transform SelfTransform { get; }
        void MoveUp();
        void MoveDown();
    }

    public enum DirectionSide
    {
        left = 1,
        right = -1
    }
}