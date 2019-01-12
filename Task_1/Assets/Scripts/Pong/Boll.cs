using UnityEngine;
using UnityEngine.UI;
using PongV2;


class CachedLink<T>
{
    private T _link;
    private GameObject _gameObject;

    public CachedLink(GameObject gameObject)
    {
        _gameObject = gameObject;
    }

    public T Component
    {
        get
        {
            if (_link == null)
                _link = _gameObject.GetComponent<T>();
            return _link;
        }
    }
}

public class Boll : MonoBehaviour
{
    public float StartImpulse;
    public Vector2 StartDirection;
    public float bagFixedTime;

    [SerializeField] private float _maxVelocity;
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private CachedLink<Transform> _selftTransform;

    private Vector2 _startPosition;
    private float xPosition;
    private int _lastPlayerHit;
    private int _nowPlayerHit;

	void Start ()
    {
        _selftTransform = new CachedLink<Transform>(gameObject);
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _startPosition = _transform.position;
        Reboot(1);
	}
	
	void Update ()
    {
        VelocityContol();
	}

    private void Reboot(float direction)
    {
        _transform.position = _startPosition;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce((StartDirection * StartImpulse) * direction, ForceMode2D.Impulse);
    }

    private void VelocityContol()
    {
        _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, _maxVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _nowPlayerHit = collision.gameObject.GetComponent<KeyboardPlayer>().ID;

            Vector2 contact = collision.contacts[0].point;
            Vector2 collisionPosition = collision.transform.position;

            if (contact.y > collisionPosition.y + 0.15)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y + ((contact.y - collisionPosition.y)*2));
            }
            else if(contact.y < collisionPosition.y - 0.15)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y - ((collisionPosition.y - contact.y)*2));
            }

            //if (_nowPlayerHit != _lastPlayerHit)
            //{
            //    collision.gameObject.GetComponent<KeyboardPlayer>().Scorre(1);
            //}
            _lastPlayerHit = _nowPlayerHit;

            collision.gameObject.GetComponent<Animator>().Play("Pin");
        }

        if(collision.gameObject.tag == "VerticalWall")
        {
            float dir = collision.gameObject.name == "WallLeft" ? 1 : -1;
            Reboot(dir);
            collision.gameObject.GetComponent<Wall>().Losses();
        }
    }
}
