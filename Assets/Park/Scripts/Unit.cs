using UnityEngine;
using Cysharp.Threading.Tasks;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitInfo unitInfo;
    public UnitInfo UnitInfo { set { unitInfo = value; } }
    [SerializeField] private UnitType[] unitType;
    public UnitType[] UnitType { set { unitType = value; } }
}
