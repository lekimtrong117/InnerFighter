using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Target_tag
{
    Player=0,
    Enemy=1,
}
public class SkillControl : MonoBehaviour
{
    public float skill_Base_HPdamage_scale;
    public float skill_Base_SPdamage;
    public float skill_Base_flyspeed;
    public float skill_Base_max_flydistance;
    public float skill_Base_duration;
    public virtual void SkillSetUp()
    {

    }
    public virtual void OnSkillCast(Vector3 cast_point, Vector3 target_point)
    {

    }


}
