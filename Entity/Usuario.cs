namespace CadastroDePessoa.Entity
{
    public class Usuario
    {
        private const int WorkFactor = 12;

        public Usuario()
        {
            IsDeleted = false;
        }

        public Guid Id {  get; set; }      

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public void Update(string name, string email, string password, DateTime createdAt, DateTime updatedAt)
        {
            Name = name;
            Email = email;
            Password = password;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
