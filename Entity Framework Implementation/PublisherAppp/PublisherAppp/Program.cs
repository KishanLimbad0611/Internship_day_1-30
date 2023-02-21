// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PublisherData;
using PublisherDomain;

using (PubContext context = new PubContext())   // creating database
{
    context.Database.EnsureCreated();
}

/*GetAuthors();
AddAuthor();
GetAuthors();
void AddAuthor()
{
    var author = new Author { FirstName = "Kishan", LastName = "Limbad" };
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}
void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();   //Linq
    foreach(var author in authors)
    {
        Console.WriteLine(author.FirstName+ " " + author.LastName);
    }
}*/



/*AddAuthorWithBook();
GetAuthorsWithBooks();

void AddAuthorWithBook()
{
    var author = new Author { FirstName = "Kishan", LastName = "Limbad" };
    author.Books.Add(new Book { Title = "Step 1 of EF", PublishDate = new DateTime(2009, 1, 1) });
    author.Books.Add(new Book { Title = "Step 2 of EF", PublishDate = new DateTime(2010, 2, 1) });
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthorsWithBooks()
{
    using var context = new PubContext();
    var authors = context.Authors.Include(a=>a.Books).ToList(); //Lambda function
    foreach(var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
        foreach(var book in author.Books)
        {
            Console.WriteLine("*" + book.Title);
        }
    }
}*/

//---------------Filtering------------------
PubContext _context = new PubContext();
/*QueryFilters();
FindIt();
void QueryFilters()
{

    //var authors = _context.Authors.Where(s=>s.FirstName == "Kishan").ToList();
    var authors = _context.Authors .Where(a => EF.Functions.Like(a.LastName, "L%")).ToList();
}
void FindIt()
{
    var authorIdTwo = _context.Authors.Find(2);
}*/


//-----------------Adding More Data------------------
/*AddSomeMoreAuthors();
SkipAndTakeAuthors();

void AddSomeMoreAuthors()
{
    _context.Authors.Add(new Author { FirstName = "Naresh", LastName = "Purohit" });
    _context.Authors.Add(new Author { FirstName = "Hemangi", LastName = "Thakkar" });
    _context.Authors.Add(new Author { FirstName = "Kishan", LastName = "Limbad" });
    _context.Authors.Add(new Author { FirstName = "Pinal", LastName = "Pithadiya" });
    _context.SaveChanges();
}
void SkipAndTakeAuthors()
{
    var groupSize = 2;
    for (int i = 0; i<5; i++)
    {
        var authors = _context.Authors.Skip(groupSize * i).Take(groupSize).ToList();
        Console.WriteLine($"Group {i}:");
        foreach(var author in authors)
        {
            Console.WriteLine($"{author.FirstName} {author.LastName}");
        }
    }
}*/


//-----------------Sorting Query-----------------
/*SortAuthor();
void SortAuthor()
{
    var authorsByLastName = _context.Authors
        .OrderBy(a => a.LastName)
        .ThenBy(a => a.FirstName).ToList();
    authorsByLastName.ForEach(a => Console.WriteLine(a.LastName + "," + a.FirstName));
}*/


//---------------Aggregate -----------------------
/*QueryAggregate();
void QueryAggregate()
{
    //var author = _context.Authors.OrderByDescending(a => a.FirstName).FirstOrDefault(a => a.LastName == "Limbad");
    var auth = _context.Authors.LastOrDefault(a => a.LastName == "Limbad");
}
*/


//---------------Insert Author-----------------
/*InsertAuthor();
void InsertAuthor()
{
    var author = new Author
    {
        FirstName = "Frank",
        LastName = "Herbert"
    };
    _context.Authors.Add(author);
    _context.SaveChanges();
}*/


//----------Retrieve and update the author-----
/*RetrieveAndUpdateAuthor();
void RetrieveAndUpdateAuthor()
{
    var author = _context.Authors.FirstOrDefault(a=>a.FirstName=="Kishan" && a.LastName=="Limbad");
    if (author != null)
    {
        author.FirstName = "Kishan";
        _context.SaveChanges();
    }
}*/



//------------Retrieve and update the multiple author--------
/*RetrieveAndUpdateMultipleAuthor();
void RetrieveAndUpdateMultipleAuthor()
{
    var authors = _context.Authors.Where(a => a.LastName == "Limbad").ToList();
    foreach (var i in authors)
    {
        i.LastName = "Limbad";
    }
    Console.WriteLine("Before " + _context.ChangeTracker.DebugView.ShortView);  //DebugView -> this will have two views Shortviews(not more details) and Longviews(In details) 
    _context.ChangeTracker.DetectChanges();       //ChangeTracker.DetectChanges  -> reads each object being tracked and update state details in entityEntry object
    Console.WriteLine("After " + _context.ChangeTracker.DebugView.ShortView);  // modify or not 
    _context.SaveChanges();
}
*/

//-----------------------Updating untracked Object----------------
/*CoordinateRetrieveAndUpdateAuthor();
void CoordinateRetrieveAndUpdateAuthor()
{
    var author = FindThatAuthor(3);
    if (author?.FirstName == "Kishan")
    {
        author.FirstName = "KL";
        SaveThatAuthor(author);
    }
}

Author FindThatAuthor(int authorId)
{
    using var shortLivedContext = new PubContext();
    return shortLivedContext.Authors.Find(authorId);
}
void SaveThatAuthor(Author author)
{
    using var anotherShortLivedContext = new PubContext();
    anotherShortLivedContext.Authors.Update(author);
    anotherShortLivedContext.SaveChanges();
}*/



//-----------------Deleting simple objects------------
/*DeleteAnAuthor();
void DeleteAnAuthor()   // deleting the first Id 
{
    var context = _context.Authors.Find(1);
    if (context!= null)
    {
        _context.Authors.Remove(context);
        _context.SaveChanges();
    }
}
*/


//---------------Tracking multiple Objects and bulk Support-------
/*InsertMultipleAuthors();
void InsertMultipleAuthors()    // using AddRange to insert, like these --> UpdateRange, RemoveRange 
{
    var authorList = new Author[]
    {
        new Author { FirstName = "abc", LastName = "one" },
        new Author { FirstName = "cde", LastName = "two" },
        new Author { FirstName = "fgh", LastName = "three" },
        new Author { FirstName = "hij", LastName = "four" }
    };
    _context.AddRange(authorList);
    _context.SaveChanges();
}


BulkAddUpdate();
void BulkAddUpdate()
{
    var authorList = new Author[]
    {
        new Author { FirstName = "eight", LastName = "one" },
        new Author { FirstName = "seven", LastName = "two" },
        new Author { FirstName = "six", LastName = "three" },
        new Author { FirstName = "five", LastName = "four" }
    };
    _context.AddRange(authorList);
    var book = _context.Books.Find(2);
    book.Title = "step 2 for EF";
    _context.SaveChanges();
}*/



//-------------------Adding Migration-------------
/////////////////////////////////////Hasdata
////////////////////////////////////script-migration -idempotent
////////////////////////////////////visual scaffolding



//----------------Adding Related Data

/*InsertNewAuthorWithNewBook();
void InsertNewAuthorWithNewBook()
{
    var author = new Author { FirstName = "Lynda", LastName = "Rutledge" };
    author.Books.Add(new Book
    {
        Title = "West With Giraffes",
        PublishDate = new DateTime(2021, 2, 2)
    });
    _context.Authors.Add(author);
    _context.SaveChanges();
}
*/

/*AddNewBookToExistingAuthorInMemory();
void AddNewBookToExistingAuthorInMemory()
{
    var author = _context.Authors.FirstOrDefault(a=>a.LastName=="Limbad");
    if (author != null)
    {
        author.Books.Add(new Book { Title = "Wool", PublishDate = new DateTime(2012, 1, 2) });
        _context.Authors.Add(author);
    }
    _context.SaveChanges();
}*/


/*
FilterUsingRelatedData();
void FilterUsingRelatedData()
{
    var recentAuthors = _context.Authors.Where(a=>a.Books.Any(b=>b.PublishDate.Year >= 2015)).ToList();
}*/

/*
ModifyingRelatedDataWhenTracked();
void ModifyingRelatedDataWhenTracked()
{
    var author = _context.Authors.Include(a => a.Books).FirstOrDefault(a => a.AuthorId == 5);
    author.Books[0].BasePrice = (decimal)10.00;
    _context.ChangeTracker.DetectChanges();
    var state = _context.ChangeTracker.DebugView.ShortView;
}*/



//-----------------------Many to Many --------------
//--->SkipNavigation
//---------Joining objects in new many to many relationship
//--------we can do by 3 approach 
/*< 1 > Existing cover + Existing Artist
< 2 > new Cover + existing Artist
< 3 > new Cover + new artist*/
/*ConnectExistingArtistAndCoverObjects();
void ConnectExistingArtistAndCoverObjects()
{
    var artistA = _context.Artists.Find(1);
    var artistB = _context.Artists.Find(2);
    var coverA = _context.Covers.Find(1);
    coverA.Artists.Add(artistA);
    coverA.Artists.Add(artistB);
    _context.SaveChanges();
}

Console.WriteLine("ends here");
Console.ReadLine();*/

//--------------one-to-one-----------------
/*GetAllBookWithTheirCover();
void GetAllBookWithTheirCover()
{
    var booksandcovers = _context.Books.Include(b => b.Cover).ToList();
    booksandcovers.ForEach(book => Console.WriteLine(book.Title + (book.Cover == null ? ": No Cover Yet " : ":" + book.Cover.DesignIdeas)));
}
*/


//---------MultiLevelInclude---------------------------//doubt
MultiLevelInclude();
void MultiLevelInclude()
{
    var authorGraph = _context.Authors
        .Include(a => a.Books)
        .ThenInclude(b => b.Cover)
        .ThenInclude(c => c.Artists)
        .FirstOrDefault(a => a.AuthorId == 5);
    Console.WriteLine(authorGraph?.FirstName + " " + authorGraph?.LastName);
    foreach (var book in authorGraph.Books)
    {
        Console.WriteLine("Books : " + book.Title);
        if (book.Cover != null)
        {
            Console.WriteLine("design ideas: " + book.Cover.DesignIdeas);
            Console.WriteLine("artist :");
            book.Cover.Artists.ForEach(a => Console.WriteLine(a.LastName + " "));
        }
    }
}
Console.ReadLine();


//----adding one-to-one-----doubt-------------   
/*NewBookAndCover();
void NewBookAndCover()
{
    var book = new Book { AuthorId = 1, Title = "Call me Kishan", PublishDate = new DateTime(1973, 1, 1) };
    book.Cover = new Cover { DesignIdeas = "Image  of Nothing?" };
    _context.Books.Add(book);
    _context.SaveChanges();
}
*/