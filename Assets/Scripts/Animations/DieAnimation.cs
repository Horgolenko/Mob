using Mob;
using UnityEngine;

namespace Animations
{
    public class DieAnimation : StateMachineBehaviour
    {
        private MobBase _mobBase;
    
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_mobBase == null) _mobBase = animator.GetComponent<MobBase>();
            _mobBase.OnDieCompleted();
        }
    }
}
