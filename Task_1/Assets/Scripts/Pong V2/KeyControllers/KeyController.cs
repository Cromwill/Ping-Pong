using UnityEngine;

[CreateAssetMenu(menuName = "Create New Key Controller")]
public class KeyController : ScriptableObject
{
    public KeyCode MoveUp;
    public KeyCode MoveDown;
    public KeyCode RotateLeft;
    public KeyCode RotateRight;
    public KeyCode UseItem;
    public KeyCode SelectShopRight;
    public KeyCode SelectShopLeft;
    public KeyCode Buy;
    
}
