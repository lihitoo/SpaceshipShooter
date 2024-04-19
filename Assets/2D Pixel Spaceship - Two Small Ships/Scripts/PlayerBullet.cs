using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public AudioClip sound;
    //public static AudioSource playerBulletSound;
    // Start is called before the first frame update
    void Start()
    {

       // playerBulletSound = gameObject.AddComponent<AudioSource>();
        //playerBulletSound.clip = sound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //HP -= 50;
        //Destroy(other.gameObject);

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("TRungr ");
          //  Destroy(gameObject);
            //audioSource.Play();
        }
    }
}
