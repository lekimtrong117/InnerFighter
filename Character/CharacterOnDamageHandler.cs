using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOnDamageHandler : MonoBehaviour
{
    public float effectiveness_ratio;
    public float HPdamgage;
    #region Datamembers

    #region Editor Settings

    [Tooltip("Material to switch to during the flash.")]
    [SerializeField] private Material flashMaterial;

    [Tooltip("Duration of the flash.")]
    [SerializeField] public float duration = 0.5f;

    #endregion
    #region Private Fields

    // The SpriteRenderer that should flash.
    [SerializeField] private SkinnedMeshRenderer skinrenderer;

    // The material that was in use, when the script started.
    [SerializeField] private Material originalMaterial;

    // The currently running coroutine.
    private Coroutine flashRoutine;

    #endregion

    #endregion


    #region Methods

    #region Unity Callbacks

    void Awake()
    {
        // Get the SpriteRenderer to be used,
        // alternatively you could set it from the inspector. 
        // Get the material that the SpriteRenderer uses, 
        // so we can switch back to it after the flash ended.
        originalMaterial = skinrenderer.material;
    }

    #endregion

    public void Flash()
    {
        // If the flashRoutine is not null, then it is currently running.
        if (flashRoutine != null)
        {
            // In this case, we should stop it first.
            // Multiple FlashRoutines the same time would cause bugs.
            StopCoroutine(flashRoutine);
        }
        // Start the Coroutine, and store the reference for it.
        if(this.gameObject.activeSelf==true)
        flashRoutine =StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        // Swap to the flashMaterial.
        skinrenderer.material = flashMaterial;

        // Pause the execution of this function for "duration" seconds.
        yield return new WaitForSeconds(duration);
        if (skinrenderer.gameObject.activeSelf == true)
        {
            // After the pause, swap back to the original material.
            skinrenderer.material = originalMaterial;

            // Set the routine to null, signaling that it's finished.
            flashRoutine = null;
        }
    }

    #endregion
    public virtual void OnDamge(DamageData damageData)
    {

    }
    public virtual void PopUpDamage()
    {
        Flash();
        PopUpTextControl damgage_pop_up = PoolManager.Instance.Spawn("PopUpText").gameObject.GetComponent<PopUpTextControl>();
        damgage_pop_up.transform.position = this.transform.position;

        if (effectiveness_ratio == 2)
        {
            damgage_pop_up.textmp.color = Color.white;
            damgage_pop_up.textmp.fontSize = 20;

        }
        else if (effectiveness_ratio == 0.5f)
        {
            damgage_pop_up.textmp.color = Color.white;
            damgage_pop_up.textmp.fontSize = 20;
        }
        else
        {
            damgage_pop_up.textmp.color = Color.white;
            damgage_pop_up.textmp.fontSize = 20;

        }
        damgage_pop_up.textmp.text = Mathf.Round(HPdamgage).ToString();
        if (gameObject.GetComponent<Yena>() != null)
        {
            damgage_pop_up.textmp.fontSize = 20;
            damgage_pop_up.textmp.color = Color.black;
            damgage_pop_up.textmp.text = Mathf.Round(HPdamgage).ToString();
        }
       // Invoke("PopUpEffectice", 0.2f);
    }
    public void PopUpEffectice()
    {
        PopUpTextControl pop_up_effect = PoolManager.Instance.Spawn("PopUpText").gameObject.GetComponent<PopUpTextControl>();
        pop_up_effect.transform.position = this.transform.position;
        switch (effectiveness_ratio)
        {
            case 2:
                {
                    pop_up_effect.textmp.text = "STRONG";
                    pop_up_effect.textmp.color = Color.red;
                    pop_up_effect.textmp.fontSize = 10;
                    break;
                }
            case 0.5f:
                {
                    pop_up_effect.textmp.text = "WEAK";
                    pop_up_effect.textmp.color = Color.green;
                    pop_up_effect.textmp.fontSize = 10;
                    break;
                }
            default:
                {
                    pop_up_effect.textmp.text = "";
                    pop_up_effect.textmp.color = Color.white;
                    pop_up_effect.textmp.fontSize = 10;
                    break;
                }
        }


    }


}
