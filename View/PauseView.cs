using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseView : BaseView
{
    public Slider slider;
    public void OnVolumeChange()
    {
        MusicManager.Instance.SetVolume(Mathf.Log10(slider.value) * 20);
    }

    public void OnPlayButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        Time.timeScale = 1;
        ViewManager.Instance.SwitchView(ViewIndex.EmptyView);
    }
}
