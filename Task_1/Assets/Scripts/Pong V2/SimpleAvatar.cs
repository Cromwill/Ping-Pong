using UnityEngine;

namespace PongV2
{
    public class SimpleAvatar : MonoBehaviour, IAvatar
    {
        [SerializeField] private float _speed;

        private Transform _selfTransform;

        public Transform SelfTransform => _selfTransform;

        private void OnEnable()
        {
            
        }

        private void Start()
        {
            _selfTransform = GetComponent<Transform>();

            //Score.Instance().OnScoreReduce += () => GetComponent<Animator>().Play("Losses");
            //Score.Instance().OnScoreAdd += () => GetComponent<Animator>().Play("Pin");
        }

        public void MoveDown()
        {
            SelfTranslate(Vector2.down);
        }
        public void MoveUp()
        {
            SelfTranslate(Vector3.up);
        }

        public void SelfTranslate(Vector3 direction)
        {
            _selfTransform.Translate(direction * _speed * Time.deltaTime);
        }
    }
}