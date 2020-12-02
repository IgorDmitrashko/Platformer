using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]
    private float dumping = 0f;

    private Vector2 offset = new Vector2(2f, 1f);
    private bool isFaceLeft;
    private Transform player;
    private int lastX;

    void Start() {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        
        FindPlayer(isFaceLeft);
    }

   
    private void FindPlayer(bool playerIsLeft) {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if(playerIsLeft)
        {
            transform.position = new Vector3(player.position.x, player.position.y );
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y);
        }
    }

    // Update is called once per frame
    void Update() {
        if(player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);

            if(currentX > lastX) isFaceLeft = true;
            else if(currentX < lastX) isFaceLeft = false;

            lastX = Mathf.RoundToInt(player.position.x);
            Vector3 target;
            if(isFaceLeft)
            {
                target = new Vector3(player.position.x , player.position.y );
            }
            else
            {
                target = new Vector3(player.position.x , player.position.y);
            }
            Vector3 currentPossition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPossition;
        }
    }
}
