namespace EczaneOtomasyon.Models
{
    public abstract class BaseEntity
    {
        public virtual string OzetBilgiVer()
        {
            return "Bu sistemde kayıtlı genel bir varlıktır.";
        }
    }
}