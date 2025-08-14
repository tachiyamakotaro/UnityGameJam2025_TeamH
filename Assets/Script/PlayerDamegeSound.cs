using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamegeSound : MonoBehaviour
{
    public AudioClip SE;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //ぶつかったオブジェクトのTagにEnemy_Bulletという名前があったら
        if (other.gameObject.tag == "Enemy_Bullet")
        {
           audioSource.PlayOneShot(SE);
        }
        if (other.gameObject.tag == "Enemy")
        {
            audioSource.PlayOneShot(SE);
        }
    }
}
