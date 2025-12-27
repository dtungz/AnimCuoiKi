using UnityEngine;
using Spine.Unity;
using Spine;

public class Player : MonoBehaviour
{
	TrackEntry CurrAnim;
	[SerializeField] GameObject Anim;
	SkeletonAnimation anim;
	PlayerMovement PM;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Awake()
	{
		PM = GetComponent<PlayerMovement>();
		anim = Anim.GetComponent<SkeletonAnimation>();
	}

	// Update is called once per frame
	void Start()
	{

	}
	private void Update()
	{
		Animation();
	}

	private void Animation()
	{
		if (PM.Movement == 0 && PM.isGrounded  && CurrAnim?.Animation.Name != "Idle")
		{
			CurrAnim = anim.AnimationState.SetAnimation(0, "Idle", true);
		}
		else if (PM.Movement != 0 && PM.isGrounded && !PM.IsRunning && CurrAnim?.Animation.Name != "walk4")
		{
			CurrAnim = anim.AnimationState.SetAnimation(0, "walk4", true);
		}
		// else if (CurrAnim?.Animation.Name != "Jump2")
		// {
		// 	CurrAnim = anim.AnimationState.SetAnimation(0, "Jump2", true);
		// }
		// else if (CurrAnim?.Animation.Name != "Jump3")
		// {
		// 	CurrAnim = anim.AnimationState.SetAnimation(0, "Jump3", true);
		// }
		// else if (CurrAnim?.Animation.Name != "Jump4")
		// {
		// 	CurrAnim = anim.AnimationState.SetAnimation(0, "Jump4", true);
		// }
		// else if (CurrAnim?.Animation.Name != "Jump5")
		// {
		// 	CurrAnim = anim.AnimationState.SetAnimation(0, "Jump5", true);
		// }
		else if (PM.Movement != 0 && PM.isGrounded && PM.IsRunning && CurrAnim?.Animation.Name != "Run")
		{
			CurrAnim = anim.AnimationState.SetAnimation(0, "Run", true);
		}
	}
}
