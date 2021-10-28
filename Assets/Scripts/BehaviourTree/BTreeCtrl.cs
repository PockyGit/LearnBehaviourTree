using BehaviorDesigner.Runtime;
using UnityEngine;

namespace BehaviourTree
{
    public class BTreeCtrl : MonoBehaviour
    {
        public BehaviorTree behaviorTree;
        public SpriteRenderer sprite;
        
        public static string SelfGo ="SelfGo";
        public static string TargetGo ="TargetGo";
        public static string RunTarget ="RunTarget";
        public static string Hp ="Hp";
        public static string MoveSpeed ="MoveSpeed";

        public void Start()
        {
            behaviorTree = GetComponent<BehaviorTree>();
            var source  =  behaviorTree.GetBehaviorSource();
            source.AddVariable(gameObject,"SelfGo");
            source.AddVariable(sprite.gameObject,"TargetGo");
            source.AddVariable(sprite.transform,"RunTarget");
            source.AddVariable(120.0f,"Hp");
            source.AddVariable(1.0f,"MoveSpeed");
        }
    }
}