using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class LoadSceenManager : MySingleton<LoadSceenManager>
{
    public GameObject UIobject;
    public Slider slider_loading;
    public Text loadPercentage;
    private int indexScence = -1;
    private string nameScence=string.Empty;
    private Action callback;
    public GameObject LoadScreenImage;
    public GameObject logoLoadingScreen;
   public Dictionary<string, GameObject> dic_LoadScreenImages = new Dictionary<string, GameObject>();
    public List<string> loadScreenImagesList = new List<string>();
    public Dictionary<string, GameObject> dic_LoadScreenQuote= new Dictionary<string, GameObject>();
    public Dictionary<string,GameObject> dic_LoadScreenTitles = new Dictionary<string, GameObject>();
    IEnumerator load;
    private void Awake()
    {
        foreach (string screen in loadScreenImagesList)
        {
            GameObject loadScreen = Instantiate(Resources.Load("LoadScreen/" + screen, typeof(GameObject))) as GameObject;
            loadScreen.transform.SetParent(LoadScreenImage.transform, false);
            dic_LoadScreenImages.Add(screen, loadScreen);
           loadScreen.gameObject.SetActive(false);
            GameObject loadScreenQuote= Instantiate(Resources.Load("LoadScreen/" +screen+"Quote", typeof(GameObject))) as GameObject;
             loadScreenQuote.transform.SetParent(UIobject.transform, false);
            dic_LoadScreenQuote.Add(screen, loadScreenQuote);
            loadScreenQuote.gameObject.SetActive(false) ;
            GameObject loadScreenTitle = Instantiate(Resources.Load("LoadScreen/" + screen+"Title", typeof(GameObject))) as GameObject;
            dic_LoadScreenTitles.Add(screen,loadScreenTitle);
            loadScreenTitle.transform.SetParent(UIobject.transform, false);
            loadScreenTitle.gameObject.SetActive(false) ;
        }    
    }
    void Update()
    {
        
    }
    public void ShowLoadScreenLogo(Action callback)
    {
        StopCoroutine("ShowLogoLoadScreenCoroutine");
        StartCoroutine("ShowLogoLoadScreenCoroutine");
        this.callback = callback;
    }    
    public IEnumerator ShowLogoLoadScreenCoroutine()
    {
        logoLoadingScreen.SetActive(true);
        yield return new WaitForSeconds(4);
        logoLoadingScreen.SetActive(false);
        callback?.Invoke();
    }   

    // khong dung index, dung namescene de dong bo voi dic_LoadScreenImages
    
    public void LoadScence(string scenceName, Action callback)
    {
        this.nameScence = scenceName;
        this.callback=callback;
        if (load != null)
        {
            StopCoroutine(load);
        }
        load = LoadProgress();
        StartCoroutine(load);
    }
    IEnumerator LoadProgress()
    {
        dic_LoadScreenImages[nameScence].gameObject.SetActive(true);
        dic_LoadScreenQuote[nameScence].gameObject.SetActive(true);
        dic_LoadScreenTitles[nameScence].gameObject.SetActive(true);
        slider_loading.value = 0;
        loadPercentage.text = "0%";
        UIobject.SetActive(true);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nameScence, LoadSceneMode.Single);
        float count = 0;
        while (count <= 50)
        {
            count++;
            yield return new WaitForSecondsRealtime(0.05f);
            slider_loading.value = count / 100f;
            loadPercentage.text = (count).ToString() + "%";
        }
        yield return new WaitUntil(() => asyncOperation.progress >= 0.5f);

        while (!asyncOperation.isDone)
        {
           yield return new WaitForSeconds(0.1f);
            slider_loading.value = asyncOperation.progress;
           loadPercentage.text = (asyncOperation.progress * 100).ToString() + "%";
        }
        slider_loading.value = 1;
        loadPercentage.text = "100%";
        dic_LoadScreenImages[nameScence].gameObject.SetActive(false);
        dic_LoadScreenQuote[nameScence].gameObject.SetActive(false);
        dic_LoadScreenTitles[nameScence].gameObject.SetActive(false);
        UIobject.SetActive(false);
        callback?.Invoke();
        indexScence = -1;
        nameScence=String.Empty;
    }
}
