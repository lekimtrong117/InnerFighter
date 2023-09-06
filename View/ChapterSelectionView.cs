using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterSelectionView : BaseView
{
   public void OnExitButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        ViewManager.Instance.SwitchView(ViewIndex.HomeView);
    }    
    public void OnVolcanoButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        ViewManager.Instance.SwitchView(ViewIndex.NormalSelectionView, null, () =>
        {
            LoadSceenManager.Instance.LoadScence("Volcano", () =>
            {
                Time.timeScale = 0;
                MusicManager.Instance.PlayMusic(MusicManager.Instance.music1);

            });
        });
    }    
}
