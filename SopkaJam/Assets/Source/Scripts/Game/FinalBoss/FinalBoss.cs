using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    private const string TOP_ATTACK = "TopAttack";
    private const string MIDDLE_ATTACK = "MiddleAttack";
    private const string BOTTOM_ATTACK = "BottomAttack";
    private const string TOP_MIDDLE_ATTACK = "TopMiddleAttack";
    private const string TOP_BOTTOM_ATTACK = "TopBottomAttack";
    private const string MODDLE_BOTTOM_ATTACK = "MiddleBottomAttack";


    [SerializeField] private Animator _animator;

    public void Attack(BossAttackType  attackType)
    {
        switch (attackType)
        {
            case BossAttackType.TOP:
                {
                    _animator.SetTrigger(TOP_ATTACK);
                    break;
                }
            case BossAttackType.MIDDLE:
                {
                    _animator.SetTrigger(MIDDLE_ATTACK);
                    break;
                }
            case BossAttackType.BOTTOM:
                {
                    _animator.SetTrigger(BOTTOM_ATTACK);
                    break;
                }
            case BossAttackType.TOP_MIDDLE:
                {
                    _animator.SetTrigger(TOP_MIDDLE_ATTACK);
                    break;
                }
            case BossAttackType.TOP_BOTTOM:
                {
                    _animator.SetTrigger(TOP_BOTTOM_ATTACK);
                    break;
                }
            case BossAttackType.MIDDLE_BOTTOM:
                {
                    _animator.SetTrigger(MODDLE_BOTTOM_ATTACK);
                    break;
                }
        }
    }
}

public enum BossAttackType
{
    TOP,
    MIDDLE,
    BOTTOM,
    TOP_MIDDLE,
    TOP_BOTTOM,
    MIDDLE_BOTTOM,
}
