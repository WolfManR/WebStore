namespace WebStore.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string AvatarUrl { get; set; }

        public string Name { get => $"{Firstname} {Surname}"; }
    }
}
