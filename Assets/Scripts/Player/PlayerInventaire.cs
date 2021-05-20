public class PlayerInventaire : Inventaire,I_Save
{
    public override bool AddItem(Item item,int nombre,out int reste)
    {
        return base.AddItem(item,nombre,out reste);
    }
    public void Save(string s)
    {

    }
    public void Load(string s)
    {

    }
}
