using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "效果SO", menuName = "Scriptable Objects/效果SO")]
public class 效果SO : ScriptableObject
{
    public string[] _tag;
    public List<MonoBehaviour> _effectScript;

}
