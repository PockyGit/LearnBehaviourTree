using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviourTree
{
    public class ActionRun : Action
    {
        public SharedTransform RunTarget;
        public SharedFloat MoveSpeed;
        public SharedFloat Hp;

        public override void OnStart()
        {
            base.OnStart();
            var behavior = BehaviorManager.instance.BehaviorTrees.Find(x => x.behavior.BehaviorName == "test");
            RunTarget.Value = behavior.behavior.GetCastedVariable<Transform>(BTreeCtrl.RunTarget);
            MoveSpeed.Value = behavior.behavior.GetCastedVariable<float>(BTreeCtrl.MoveSpeed);
            Hp.Value = behavior.behavior.GetCastedVariable<float>(BTreeCtrl.Hp);
        }

        public override TaskStatus OnUpdate()
        {
            if (RunTarget.Value == null
                || Vector3.Distance(RunTarget.Value.position, transform.position) > 0.5f
                || Hp.Value <= 0)
            {
                transform.position += transform.right * MoveSpeed.Value * Time.deltaTime;
                return TaskStatus.Running;
            }

            Debug.Log($"ActionRun.name = {RunTarget.Value.gameObject.name}");
            return TaskStatus.Success;
        }
    }
}