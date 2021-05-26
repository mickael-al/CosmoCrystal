using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemEffect/PieceAddEffect", order = 1)]
public class PieceAddEffect : ItemEffect
{
    public override bool Effect(Character character,int nombre = -1)
    {
        if(character.GetComponent<Inventaire>())
        {
           character.GetComponent<Inventaire>().Piece += nombre;
        }
        return true;
    }
}
