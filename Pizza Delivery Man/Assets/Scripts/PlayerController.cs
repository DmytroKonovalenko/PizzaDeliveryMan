using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Joystik joystick;
    [SerializeField] public float moveSpeed;
    [SerializeField] private GameObject losePanel;
    public GameObject jostickImage;
    public float Speed = .25f;
    public float MaxSpeed = 2.5f;
    float CurrentSpeed;
        private void Update()
        {
        float pedalspeed;
        pedalspeed = joystick.Vertical();
        CurrentSpeed =Mathf.Clamp( CurrentSpeed + ((Speed / 100) * Time.deltaTime) * pedalspeed, -MaxSpeed,  MaxSpeed / 100 );
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, joystick.Vertical() * moveSpeed);
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Time.timeScale = 0;
            losePanel.SetActive(true);
            jostickImage.SetActive(false);
            

        }
    }

}
