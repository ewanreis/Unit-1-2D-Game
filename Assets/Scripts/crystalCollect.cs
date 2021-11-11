using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalCollect : MonoBehaviour
{
    public AudioSource crystalSource;
    // Start is called before the first frame update
    void Start()
    {
        crystalSource = GetComponent<AudioSource>();
    }
     void OnTriggerEnter2D(Collider2D other)
     {
         Destroy(gameObject);
     }
}
