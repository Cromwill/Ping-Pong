using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] private float MoveSpeed;
    [SerializeField] private float RotateSpeed;

    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    public KeyCode RotateLeft;
    public KeyCode RotateRight;
    public Text PlayerScorreText;

    private Transform _transform;
    private int _playerScorre;

    void Start ()
    {
        _transform = GetComponent<Transform>();
	}
	

	void Update ()
    {
        float tempY = _transform.position.y;

		if(Input.GetKey(MoveRight) && tempY > -3.5)
        {
            _transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(MoveLeft) && tempY < 3.5)
        {
           _transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime, Space.World);
        }
    }

    public void Scorre(int score)
    {
        //_playerScorre += score;
        //PlayerScorreText.text = "Счет: " + _playerScorre;
    }
}
