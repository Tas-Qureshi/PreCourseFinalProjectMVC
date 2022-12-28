using Microsoft.AspNetCore.Mvc;

public class AddressBooksController : Controller
{
    private readonly ApplicationDbContext _db;
    public AddressBooksController(ApplicationDbContext db)
    {
        _db = db;
    }
// Search Data by Name or Street
    [HttpGet]
    public IActionResult Index(string SearchString)
    {
        var tempBooks = from b in _db.AddressBooks
                        select b;
        if (!string.IsNullOrEmpty(SearchString))
        {
            tempBooks = tempBooks.Where(u => u.Name.ToLower().Contains(SearchString.ToLower()) || u.Street.ToLower().Contains(SearchString.ToLower()));
        }
        return View(tempBooks.ToList());
    }

    // Address Book Details
    public IActionResult Details(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var tempAddressBook = _db.AddressBooks.FirstOrDefault(u => u.Id == id);
        if (tempAddressBook == null)
        {
            return NotFound();
        }
        var VM = new AddressBookVM()
        {
            Name = tempAddressBook.Name,
            Street = tempAddressBook.Street,
            StreetNo = tempAddressBook.StreetNo,
            City = tempAddressBook.City,
            Email = tempAddressBook.Email,
            PhoneNumber = tempAddressBook.PhoneNumber

        };
        return View(VM);
    }


    //Get Data to Create
    public IActionResult Create()
    {
        return View();
    }
    // Create/Add data to DB

    [HttpPost]
    public IActionResult Create(AddressBookVM obj)
    {
        var nextId = _db.AddressBooks.Count + 1;
        if (ModelState.IsValid)
        {
            var AddressBookToAdd = new AddressBook()
            {
                Id = nextId,
                Name = obj.Name,
                Email = obj.Email,
                Street = obj.Street,
                StreetNo = obj.StreetNo,
                City = obj.City,
                PhoneNumber = obj.PhoneNumber
            };
            _db.AddressBooks.Add(AddressBookToAdd);
            TempData["success"] = "Address Book Created Successfully";
            return RedirectToAction(nameof(Index));
        }
        return View(obj);
    }

    //Get Data to Delete Address
    public IActionResult Delete(int? id)
    {

        if (id == null || id == 0)
        {
            return NotFound();
        }

        var tempAddressBook = _db.AddressBooks.FirstOrDefault(u => u.Id == id);
        if (tempAddressBook == null)
        {
            return NotFound();
        }
        AddressBookVM VM = new AddressBookVM()
        {
            Name = tempAddressBook.Name,
            Street = tempAddressBook.Street,
            StreetNo = tempAddressBook.StreetNo,
            City = tempAddressBook.City,
            Email = tempAddressBook.Email,
            PhoneNumber = tempAddressBook.PhoneNumber
        };

        return View(VM);
    }
    // Delete data from DB
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteBook(int? id)
    {
        var AddressBookFromDbFirst = _db.AddressBooks.FirstOrDefault(u => u.Id == id);
        if (id == null && id == 0)
        {
            return NotFound();
        }
        _db.AddressBooks.Remove(AddressBookFromDbFirst);
        TempData["success"] = "Address Book Deleted Successfully";
        return RedirectToAction(nameof(Index));

    }

    //Get Data to Update Address
    public IActionResult Edit(int? id)
    {

        if (id == null && id == 0)
        {
            return NotFound();
        }

        var tempAddressBook = _db.AddressBooks.FirstOrDefault(u => u.Id == id);
        if (tempAddressBook == null)
        {
            return NotFound();
        }
        AddressBookVM VM = new AddressBookVM()
        {
            Name = tempAddressBook.Name,
            Street = tempAddressBook.Street,
            StreetNo = tempAddressBook.StreetNo,
            City = tempAddressBook.City,
            Email = tempAddressBook.Email,
            PhoneNumber = tempAddressBook.PhoneNumber
        };

        return View(VM);
    }

    // Update data to DB
    [HttpPost]

    public IActionResult Edit(int? id, AddressBookVM VM)
    {
        var AddressBookFromDbFirst = _db.AddressBooks.FirstOrDefault(u => u.Id == id);
        if (id == null && id == 0)
        {
            return NotFound();
        }
        else
        {
            //AddressBookFromDbFirst.Id = id;
            AddressBookFromDbFirst.Name = VM.Name;
            AddressBookFromDbFirst.Street = VM.Street;
            AddressBookFromDbFirst.StreetNo = VM.StreetNo;
            AddressBookFromDbFirst.City = VM.City;
            AddressBookFromDbFirst.Email = VM.Email;
            AddressBookFromDbFirst.PhoneNumber = VM.PhoneNumber;
        }
        TempData["success"] = "Address Book Updated Successfully";
        return RedirectToAction(nameof(Index));

    }
    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
        var AddressBooksList = _db.AddressBooks;
        return Json(new { data = AddressBooksList });
    }
    #endregion


}