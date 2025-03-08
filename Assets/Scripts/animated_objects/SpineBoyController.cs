using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class SpineBoyController : MonoBehaviour, IInteractable
{
    private ExposedList<Spine.Animation> _animations;
    private SkeletonAnimation _skeletonAnimation;
    private int _animationsCount;

    private void Awake()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();

        _animations = _skeletonAnimation.skeletonDataAsset.GetSkeletonData(false).Animations;
        _animationsCount = _animations.Count;
    }

    public void Interact()
    {
        int randomIndex = Random.Range(0, _animationsCount);
        var name = _animations.Items[randomIndex].Name;
        _skeletonAnimation.AnimationState.SetAnimation(0, name, true);
    }
}
