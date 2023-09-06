using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleRing : MonoBehaviour
{
    public GameObject temple;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Yena.Instance.characterController.enabled = false;
            Yena.Instance.trans.position = Vector3.zero;
            Yena.Instance.characterController.enabled = true;
            EnemySpawnManager.Instance.enable = true;
            Destroy(temple);
        }
    }

}
