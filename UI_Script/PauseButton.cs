using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseButton : MonoBehaviour
{
	

    public void OnPauseButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Time.timeScale = 0;
        ViewManager.Instance.SwitchView(ViewIndex.PauseView);
    }
}
