using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject _pointUp;
    [SerializeField] private GameObject _pointDown;
    public int _speed = 8;

    private bool _movingUp;

    void Update() {
        if(transform.position.y >= _pointUp.transform.position.y)
        {
            _movingUp = false;
        }
        else if(transform.position.y <= _pointDown.transform.position.y)
        {
            _movingUp = true;
        }

        Move();
    }
    private void Move() {
        if(_movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointUp.transform.position, _speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointDown.transform.position, _speed * Time.deltaTime);
        }

    }

}
