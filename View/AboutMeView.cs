using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutMeView : BaseView
{
    public void OnExitButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        ViewManager.Instance.SwitchView(ViewIndex.HomeView);
    }
}
