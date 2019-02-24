using UnityEngine;

/// <summary>
/// Suspends the coroutine execution until currently triggered animation clip in the supplied animator evaluates to true.
/// </summary>
public sealed class WaitForAnimation : CustomYieldInstruction
{
	private Animator animator;
	private string lastClipName;
	private float innerTime = -1;

	public override bool keepWaiting
	{
		get
		{
            AnimationClip currentClip = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
            if (string.CompareOrdinal(currentClip.name, lastClipName) != 0)
			{
				if (innerTime == -1)
					innerTime = Time.realtimeSinceStartup + currentClip.length;

				if (WaitedFor(innerTime))
					return false;
			}
			return true;
		}
	}

	/// <summary>
	/// Creates a yield instruction to wait until currently triggered clip is played.
	/// </summary>
	/// <param name="animator"></param>
	public WaitForAnimation(Animator animator)
	{
		this.animator = animator;
		lastClipName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
	}

	private bool WaitedFor(float time)
	{
		return Time.realtimeSinceStartup >= time;
	}
}
