using BehaviorDesigner.Runtime;
using UnityEngine;

public static class BehaviorSourceExtend
{
    public static void AddVariable<T>(this BehaviorSource pointer, T t, string name)
    {
        switch (t)
        {
            case GameObject gameObject:
            {
                var sharedGameObject = new SharedGameObject();
                sharedGameObject.Value = gameObject;
                sharedGameObject.Name = name;
                pointer.Variables.Add(sharedGameObject);
                break;
            }
            case Transform transform:
            {
                var sharedGameObject = new SharedTransform();
                sharedGameObject.Value = transform;
                sharedGameObject.Name = name;
                pointer.Variables.Add(sharedGameObject);
                break;
            }
            case float value:
            {
                var sharedGameObject = new SharedFloat();
                sharedGameObject.Value = value;
                sharedGameObject.Name = name;
                pointer.Variables.Add(sharedGameObject);
                break;
            }
        }
    }

    public static T GetCastedVariable<T>(this Behavior pointer, string name)
    {
        return (T) pointer.GetVariable(name).GetValue();
    }
}