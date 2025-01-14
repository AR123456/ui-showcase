using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionSound;
    [SerializeField]
    private AudioClip _explosionSoundClip;
    [SerializeField]
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        // this will be called when the Explosion starts so just destroy
        Destroy(this.gameObject, 3f);
        if (_audioSource == null)
        {
            Debug.LogError("AudioSource explosion is null");
        }
        else
        {
            _audioSource.clip = _explosionSoundClip;
        }
    }

   
}
