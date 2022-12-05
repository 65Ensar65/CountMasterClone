public class PlayerAnimatorController : MyBaseBehaviour
{
    public void GetAnimator()
    {
        transform.PlayAnim((int)PlayerAnimState.RUN);
    }
}
public enum PlayerAnimState
{
    IDLE,
    RUN
}

