using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HomeView : BaseView
{
    public TextMeshProUGUI score_tmp;
    public void OnPlaybutton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        ViewManager.Instance.SwitchView(ViewIndex.ChapterSelectionView, null, () =>
        {

            //LoadSceenManager.Instance.LoadScence("Volcano", () =>
            //{

            //});
        });
    }
    public void OnTutorialButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        ViewManager.Instance.SwitchView(ViewIndex.TutorialView, null);
    }
    public void OnAboutMeButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        ViewManager.Instance.SwitchView(ViewIndex.AboutMeView, null);
    }
    public override void Setup(ViewParam viewParam)
    {
        base.Setup(viewParam);
        if (MusicManager.Instance.audioSource.isPlaying == false || (MusicManager.Instance.audioSource.isPlaying && MusicManager.Instance.audioSource.clip != MusicManager.Instance.theme))
        {
            MusicManager.Instance.PlayMusic(MusicManager.Instance.theme);
        }
        float score = DataAPIController.Instance.ReadHighestScore();
        score_tmp.text = "Your Highest Score " + score.ToString();
    }

}
