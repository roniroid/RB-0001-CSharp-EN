namespace Roniroid.Basics.EF.Entities;

public class User
    {        
		public int Id { get; set; }
		public int PersonId { get; set; }
		public string Username { get; set; }
		public byte[] Password { get; set; }
		public byte[] Salt { get; set; }
		public string Email { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime LastLoginDate { get; set; }
		public Person Person { get; set; }
    }