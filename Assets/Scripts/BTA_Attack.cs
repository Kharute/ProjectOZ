using UnityEngine;
using UnityEngine.AI;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class BTA_Attack : Action
    {
        public Enemy enemy;

        public override TaskStatus OnUpdate()
        {
            if (enemy.Attack())
            {
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }


    }
}