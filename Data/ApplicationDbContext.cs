public class ApplicationDbContext{

  public List<AddressBook> AddressBooks {get;set;}

    public ApplicationDbContext()
    {


        AddressBooks = new List<AddressBook>(){
            new AddressBook() {Id =1, Name ="Tas", Street = "A Street", StreetNo = 23, City="Stockholm",Email = "tas@salt.dev", PhoneNumber="2334" },
            new AddressBook() {Id =2, Name ="Zain", Street = "B Street", StreetNo = 22, City="Stockholm",Email = "zain@salt.dev", PhoneNumber="332334" },
            new AddressBook() {Id =3, Name ="Adam", Street = "A Street", StreetNo = 23, City="ISb",Email = "adam@salt.dev", PhoneNumber="233334" },
            new AddressBook() {Id =4, Name ="Dani", Street = "A Street", StreetNo = 23, City="Karachi",Email = "dani@salt.dev", PhoneNumber="234434" },
        };

    }   
}