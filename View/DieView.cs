using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DieView : BaseView
{
    public Animator animator;
    public TextMeshProUGUI tmp;
    IEnumerator delayreturnhome;

    public override void Setup(ViewParam viewParam)
    {
        base.Setup(viewParam);
        animator.Play("Die");
        tmp.text = Yena.Instance.attribute.score.ToString();
       
        

            MusicManager.Instance.PlayMusic(MusicManager.Instance.die);
        
    }
    public void OnExitButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        float current_score = DataAPIController.Instance.ReadHighestScore();
        
        if (Yena.Instance.attribute.score > current_score)
        {
            DataAPIController.Instance.UpdateHighestScore(Yena.Instance.attribute.score);
            Debug.Log("score update");
        }
        PoolManager.Instance.Reset();
        LoadSceenManager.Instance.LoadScence("Buffer", () =>
        {
            ViewManager.Instance.SwitchView(ViewIndex.HomeView, null, () =>
            {
                Time.timeScale = 1;
            }         
       );
        });
    }
  
    
}
