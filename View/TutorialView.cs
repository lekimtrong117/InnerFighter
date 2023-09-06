using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialView :BaseView
{
    public Button exitButton;
    public Button previousButton;
    public Button nextButton;
    public TextMeshProUGUI page_name;
    public TextMeshProUGUI tip;
    public Image tutorrial_image;
    int page_index;
    public int number_of_page;
    public string[] pagename_contents;
    public string[] tip_contents;

   [SerializeField] public Sprite[] sprites;
    public override void Setup(ViewParam viewParam)
    {
        base.Setup(viewParam);
        page_index = 0;
        page_name.text = pagename_contents[page_index];
        tip.text=tip_contents[page_index];
        tutorrial_image.sprite= sprites[page_index];
    }
    public void OnNextButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        page_index++;
        if(page_index>=number_of_page)
        {
            page_index=0;
        }    
        page_name.text = pagename_contents[page_index];
        tip.text = tip_contents[page_index];
        tutorrial_image.sprite = sprites[page_index];
    }
    public void OnPreviousButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        page_index--;
        if (page_index <=-1 )
        {
            page_index = number_of_page-1;
        }
        page_name.text = pagename_contents[page_index];
        tip.text = tip_contents[page_index];
        tutorrial_image.sprite = sprites[page_index];
    }
    public void OnExitButton()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.click);
        ViewManager.Instance.SwitchView(ViewIndex.HomeView);
    }    
}
