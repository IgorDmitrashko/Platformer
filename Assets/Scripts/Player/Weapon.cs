using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _ball;
    private void Start() {
        Player.Singelton.ShotEvent += Shoot;
    }

    public void Shoot(AudioSource audio) {
        Instantiate(_ball, _firePoint.position, _firePoint.rotation);
    }

    public void Shoot() {
        Instantiate(_ball, _firePoint.position, _firePoint.rotation);
    }
}
