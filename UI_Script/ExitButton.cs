using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
   public void OnExitButton()
    {
        float current_score = DataAPIController.Instance.ReadHighestScore();

        if (Yena.Instance.attribute.score > current_score)
        {
            DataAPIController.Instance.UpdateHighestScore(Yena.Instance.attribute.score);
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
