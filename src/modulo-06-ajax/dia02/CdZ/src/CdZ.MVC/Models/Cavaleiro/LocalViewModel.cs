namespace CdZ.MVC.Models.Cavaleiro
{
    public class LocalViewModel
    {
        public int Id { get; set; }
        public string Texto { get; set; }

        public Dominio.Local ToModel()
        {
            return new Dominio.Local(Id, Texto);
        }
    }
}