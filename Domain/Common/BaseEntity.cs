namespace Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Rename(string newName)
        {
            if (!string.IsNullOrEmpty(newName))
                Name = newName;
        }
    }
}