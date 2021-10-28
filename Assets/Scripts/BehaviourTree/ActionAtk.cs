using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviourTree
{
    public class ActionAtk : Action
    {
        public SharedTransform AtkTarget;
        public SharedFloat Hp;

        public override void OnStart()
        {
            base.OnStart();
            var behavior = BehaviorManager.instance.BehaviorTrees.Find(x => x.behavior.BehaviorName == "test");
            AtkTarget.Value = behavior.behavior.GetCastedVariable<Transform>(BTreeCtrl.RunTarget);
            Hp.Value = behavior.behavior.GetCastedVariable<float>(BTreeCtrl.Hp);
        }

        public override TaskStatus OnUpdate()
        {
            if (AtkTarget == null)
                return TaskStatus.Failure;
            if (Hp.Value <= 0)
                return TaskStatus.Success;

            Hp.Value -= 10;
            Debug.Log($"ActionAtk.name = {gameObject.name}  hp = {Hp.Value}");

            return TaskStatus.Running;
        }
    }
}