using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    private const string ATTACK = "Attack";


    [SerializeField] private Animator _topHandAnimator;
    [SerializeField] private Animator _middleHandAnimator;
    [SerializeField] private Animator _bottomHandAnimator;

    public void Attack(BossAttackType  attackType)
    {
        switch (attackType)
        {
            case BossAttackType.TOP:
                {
                    _topHandAnimator.SetTrigger(ATTACK);
                    break;
                }
            case BossAttackType.MIDDLE:
                {
                    _middleHandAnimator.SetTrigger(ATTACK);
                    break;
                }
            case BossAttackType.BOTTOM:
                {
                    _bottomHandAnimator.SetTrigger(ATTACK);
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
}
