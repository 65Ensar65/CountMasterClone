using UnityEngine;

public static class AnimatorExtensions
{
    public static void PlayAnim(this Transform tr, int animState )
    {
        Animator anim = tr.GetComponent<Animator>();

        if(anim != null)
        {
            anim.SetInteger("animState", animState);
        }
    }

    public static void PlayAnim(this GameObject obj, int animState)
    {
        Animator anim = obj.GetComponent<Animator>();

        if (anim != null)
        {
            anim.SetInteger("animState", animState);
        }
    }
}
