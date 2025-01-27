using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;
    private bool _isEnemyLaser = false;
     
    void Update()
    {
        if (_isEnemyLaser == false)
        {
            MoveUp();
        }
        else  
        {
            MoveDown();
        }
    }
    void MoveUp() {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if (transform.position.y > 8f)
        {
            // if this object has a parent distroy it too
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }
    void MoveDown()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -8f)
        {
            // if this object has a parent distroy it too
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }
    // call from Enemy - Update() method
    public void AssignEnemyLaser()
    {
        _isEnemyLaser = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check for player hit by laser
        if (other.tag=="Player" && _isEnemyLaser==true)
        {
            // create ref to player and get player component so we can get to its damage method 
            Player player = other.GetComponent<Player>();
            // check to see if the player component is on the thing we hit
            if (player !=null)
            {
                // call the players method to apply damage 
                player.Damage();
            }
        }
    }
}
