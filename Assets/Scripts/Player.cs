using UnityEngine;
using Spine.Unity;
using Spine;

public class Player : MonoBehaviour
{
	TrackEntry CurrAnim;
	[SerializeField] GameObject Anim;
	SkeletonAnimation anim;
	PlayerMovement PM;

	Rigidbody2D rb;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Awake()
	{
		PM = GetComponent<PlayerMovement>();
		anim = Anim.GetComponent<SkeletonAnimation>();
		rb = GetComponent<Rigidbody2D>();
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
		if (PM.Movement == 0 && PM.isGrounded && CurrAnim?.Animation.Name != "Idle")
		{
			CurrAnim = anim.AnimationState.SetAnimation(0, "Idle", true);
		}
		else if (PM.Movement != 0 && PM.isGrounded && !PM.IsRunning && CurrAnim?.Animation.Name != "walk4")
		{
			CurrAnim = anim.AnimationState.SetAnimation(0, "walk4", true);
		}
		else if (!PM.isGrounded && rb.linearVelocityY >= 0.5f && CurrAnim?.Animation.Name != "Up")
		{
			CurrAnim = anim.AnimationState.SetAnimation(0, "Up", true);
		}
		else if (!PM.isGrounded && rb.linearVelocityY < 0.5f && rb.linearVelocityY > -0.5f && CurrAnim?.Animation.Name != "Up2")
		{
			CurrAnim = anim.AnimationState.SetAnimation(0, "Up2", true);
		}
		else if (!PM.isGrounded && rb.linearVelocityY <= -0.5f && CurrAnim?.Animation.Name != "Down")
		{
			CurrAnim = anim.AnimationState.SetAnimation(0, "Down", true);
		}
		else if (PM.Movement != 0 && PM.isGrounded && PM.IsRunning && CurrAnim?.Animation.Name != "Run")
		{
			CurrAnim = anim.AnimationState.SetAnimation(0, "Run", true);
		}
	}
}
