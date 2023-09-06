using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewIndex
{
    EmptyView = 0,
    HomeView = 1,
    WeaponView = 2,
    TutorialView = 3,
    AboutMeView = 4,
    InGameView = 5,
    ChapterSelectionView,
    NormalSelectionView,
    SpellSelectionView,
    DashSelectionView,
    SpinView,
    DieView,
    PauseView,
}

public class ViewConfig
{
    public static ViewIndex[] viewIndies =
    {
        ViewIndex.EmptyView,
        ViewIndex.HomeView,
        ViewIndex.WeaponView,
        ViewIndex.TutorialView,
        ViewIndex.AboutMeView,
        ViewIndex.InGameView,
        ViewIndex.ChapterSelectionView,
        ViewIndex.NormalSelectionView,
        ViewIndex.SpellSelectionView,
        ViewIndex.DashSelectionView,
        ViewIndex.SpinView,
       ViewIndex.DieView,
       ViewIndex.PauseView,
    };
}
public class ViewParam
{

}
public class WeaponViewParam : ViewParam
{
    public string nameWeapon;
}