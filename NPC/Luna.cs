using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luna : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip talk;

    public float dialog_height = 2;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
       Transform dialog= PrefabManager.Instance.CreateNPCDialog(this.transform, new Vector3(0, dialog_height, 0), "Dagon is out of control, you need to cool him down or anger will consume you",6,Color.white, 4);
        dialog.SetParent(MusicManager.Instance.transform);
        audioSource.PlayOneShot(talk);
    }

}
