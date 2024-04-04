using UnityEngine;
using Cysharp.Threading.Tasks;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitInfo unitInfo;
    public UnitInfo UnitInfo { set { unitInfo = value; } }
}
