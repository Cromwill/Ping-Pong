using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Pointer : MonoBehaviour
{
    [SerializeField]private float MoveColddown;
    [SerializeField]private float Speed;
    [SerializeField]private GameObject[] Buttons;
    [SerializeField]private float indent;

    private Vector2 _direction;
    private Vector2 _moving;
    private RectTransform _rectTransform;
    private PointerEventData pointer;

    private float _moveTime;
    private int _buttonCounter = 0;


    void Start ()
    {
        _direction = Vector2.right;
        _rectTransform = GetComponent<RectTransform>();
        SetPointerOnPositin(_buttonCounter);
        pointer = new PointerEventData(EventSystem.current);
        Buttons[_buttonCounter].GetComponent<Button>().OnPointerEnter(pointer);
    }
	

	void Update ()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovePointer(-1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePointer(1);
        }
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            Buttons[_buttonCounter].GetComponent<Button>().OnPointerClick(pointer);
        }
    }

    private void MovePointer(int direction) // -1 - down; 1 - up
    {
        Buttons[_buttonCounter].GetComponent<Button>().OnPointerExit(pointer);

        ChangeButtonCounter(direction);

        SetPointerOnPositin(_buttonCounter);
        Buttons[_buttonCounter].GetComponent<Button>().OnPointerEnter(pointer);
    }

    private void Move()
    {
        _moving = _direction * Speed * Time.deltaTime;
        _rectTransform.Translate(_moving, Space.World);
        _moveTime--;

        if (_moveTime < 0)
        {
            _direction *= -1;
            _moveTime = MoveColddown;
        }
    }

    private void SetPointerOnPositin(int index)
    {
        RectTransform buttonRect = Buttons[index].GetComponent<RectTransform>();
        _rectTransform.localPosition = new Vector2(buttonRect.rect.xMin + indent, buttonRect.localPosition.y);
    }
    private void ChangeButtonCounter(int shift)
    {
        _buttonCounter += shift;
        if (_buttonCounter > Buttons.Length - 1) _buttonCounter = 0;
        if (_buttonCounter < 0) _buttonCounter = Buttons.Length - 1;
    }


}
