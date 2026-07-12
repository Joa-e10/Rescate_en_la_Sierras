using UnityEngine;
using UnityEngine.UI;

public abstract class Keys : MonoBehaviour
{
    [SerializeField]protected ItemData _data;

    public ItemData GetKeyData() 
    {
        return _data;
    }
}
