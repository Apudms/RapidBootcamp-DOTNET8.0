//// See https://aka.ms/new-console-template for more information
////Console.WriteLine("Hello, World!");
////Console.WriteLine("Rapid .NET Bootcamp 2024");

////

////string nama = "Muhammad Saefudin";
////char jenisKelamin = 'L';

////string firstName = "Muhammad";
////string lastName = "Saefudin";

////int age = 22;
////double height = 173.5;
////bool isMariage = false;

////Console.WriteLine("Nama Depan: " + firstName);
////Console.WriteLine($"Nama Belakang: {lastName}");
////Console.WriteLine($"Nama Lengkap: {firstName} {lastName}");
////Console.WriteLine("Usia: " + age + "CM");
////Console.WriteLine("Tinggi Badan: " + height);
////Console.WriteLine("Status: " + isMariage);

////

////string firstName = "Muhammad";
////string lastName = "Saefudin";

////int age = 22;
////var height = 173.5;
////bool isMariage = false;

////var fullName = "Muhammad Saefudin";
////fullName = "Apud";

////var saldo = 100_000_000;

////var strSql = @"SELECT * FROM EMPLOYEES
////               WHERE EmpId = @EmpId
////               ORDER BY EmpId ASC";

////

////double double1 = 99.99;
////int number2 = double1;

////int number1 = 99;
////double double2 = number1;

////double double1 = 99.99;
////int number2 = Convert.ToInt32(double1);
////Console.WriteLine("Hasil Double ke INT versi pertama: " + number2);

////double double1 = 99.99;
////int number2 = (int)double1;
////Console.WriteLine("Hasil Double ke INT versi kedua: " + number2);

////

//// 
////using System.Collections;

//////
//////int number1 = 99;
//////int number2 = number1;
//////number1 = 199;
//////Console.WriteLine("Nomor 1: " + number1);
//////Console.WriteLine("Nomor 2: " + number2);

//////

////Student student1 = new Student();
////student1.Name = "Apud";
////student1.Age = 22;

////Student student2 = student1;
////student1.Name = "Sae";
////student1.Age = 26;

////Student student3 = new Student();
////student1.Name = "Muh";
////student1.Age = 22;

//////Console.WriteLine("Student 1 Name: " + student1.Name);
//////Console.WriteLine("Student 1 Age: " + student1.Age);
//////Console.WriteLine("Student 2 Name: " + student2.Name);
//////Console.WriteLine("Student 2 Age: " + student2.Age);


////Lecture lecture1 = new Lecture();
////lecture1.LectureId = 1;
////lecture1.LectureName = "Budi";

////var result1 = student1 is Student;
////var result2 = student1 is Lecture;
////var result3 = student2 == student1;
////var result4 = student3 == student1;
////var result5 = student1.Age == student3.Age;

////Console.WriteLine(result1);
////Console.WriteLine(result2);
////Console.WriteLine(result3);
////Console.WriteLine(result4);
////Console.WriteLine(result5);

////

////
//using System.Diagnostics;

//Console.Write("Input Mata Kuliah: ");
//int jumlah = Convert.ToInt32(Console.ReadLine());

//double sumOfScore = 0;

//for (int i = 1; i <= jumlah; i++)
//{
//    Console.Write($"Input Nilai Mata Kuliah {i} (1-100) : ");
//    sumOfScore += Convert.ToDouble(Console.ReadLine());

//}


//// Calculate grade
//// 86 - 100 = A
//// 71 - 85 = B
//// 56 - 70 = C
//// 40 - 55 = D
//// E

//try
//{
//    double score = sumOfScore / jumlah;
//    string gradeResult = CalculateGrade(score);
//    Console.WriteLine($"Score: {score} - Grade: {gradeResult}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"{ex.Message }");
//}

//string CalculateGrade(double score)
//{
//    string grade = string.Empty;

//    if (score > 100)
//    {
//        Console.WriteLine("The maximum value cannot exceed 100");
//    }
//    else if (score >= 86 && score <= 100)
//    {
//        grade = "A";
//    }
//    else if (score >= 71 && score <= 85)
//    {
//        grade = "B";
//    }
//    else if (score >= 56 && score <= 70)
//    {
//        grade = "C";
//    }
//    else if (score >= 40 && score <= 55)
//    {
//        grade = "D";
//    }
//    else
//    {
//        grade = "E";
//    }

//    return grade;
//}


////class Student()
////{
////    public string Name { get; set; }
////    public int Age { get; set; }
////}

////class Lecture()
////{
////    public int LectureId { get; set; }
////    public string LectureName { get; set; }
////}



//using RapidBootcamp.ConsoleApp.Domain;

//Student student1 = new Student();
////student1.setNim("1833227799");
////student1.setName("Muhammad Saefudin");
//student1.Nim = "1833227799";
//student1.Name = "Muhammad Saefudin";

//Console.WriteLine(student1.Nim + " - " + student1.Name);

//

//using RapidBootcamp.ConsoleApp.Domain;

//List<Student> listStudents = new List<Student>();
//int jumlah = Convert.ToInt32(Console.ReadLine());
//int counter = 0;

//while (counter < jumlah)
//{
//    Student student = new Student();
//    Console.WriteLine("Masukkan NIM: ");
//    student.Nim = Console.ReadLine();



//    listStudents.Add(student);
//    counter++;
//}

// =======================================================================================================
// Dari Pak Erick
// =======================================================================================================

// See https://aka.ms/new-console-template for more information

//string firstName = "Erick";
//string lastName = "Kurniawan";

//int age = 25;
//var height = 170.5;
//bool isMarried = false;

//string nama;
//nama = "Erick Kurniawan";


//var fullName = "Erick Kurniawan";
//fullName = "Agus Kurniawan";

//var saldo = 100_000_000;

//var strSql = @"select * from Employees 
//               where EmpId=@EmpId 
//               order by EmpId asc";


//int number1 = 99;

//Console.WriteLine("Number 1: " + number1.ToString());
//Console.WriteLine($"Nama anda: {firstName} {lastName}");
//Console.WriteLine("Nama anda : " + firstName + " " + lastName);
//Console.WriteLine(34.40M);




//using System.Collections;

//int number1 = 99;
//int number2 = number1;
//number1 = 199;

////Console.WriteLine("Number 1: " + number1);
////Console.WriteLine("Number 2: " + number2);


//Student student1 = new Student();
//student1.Name = "Erick";
//student1.Age = 25;

//Student student2 = student1;
//student1.Name = "Agus";

//Student student3 = new Student();
//student3.Name = "Erick";
//student3.Age = 25;

//Lecturer lecturer1 = new Lecturer();
//lecturer1.LecturerId = 1;
//lecturer1.LecturerName = "Budi";

//var result1 = student1 is Student;
//var result2 = student1 is Lecturer;
//var result3 = student2 == student1;
//var result4 = student3 == student1;
//var result5 = student1.Age == student3.Age;

//Console.WriteLine(result1);
//Console.WriteLine(result2);
//Console.WriteLine(result3);
//Console.WriteLine(result4);
//Console.WriteLine(result5);

//Console.WriteLine("Student 1: " + student1.Name + " " + student1.Age);
//Console.WriteLine("Student 2: " + student2.Name + " " + student2.Age);

//Hari hari1 = Hari.Senin;
//Console.WriteLine(hari1);

//string[] names = new string[3];
//names[0] = "Erick";
//names[1] = "Agus";
//names[2] = "Budi";

//foreach (var name in names)
//{
//    Console.WriteLine(name);
//}

//int[] ints = new int[3];
//ints[0] = 1;
//ints[1] = 2;
//ints[2] = 3;


////tidak disarankan untuk digunakan
//ArrayList list = new ArrayList();
//list.Add("Erick");
//list.Add("Budi");
//list.Add(12);
//list.Add("Joe");

//foreach (string item in list)
//{
//    Console.WriteLine(item);
//}

//List<string> strNama = new List<string>();
//strNama.Add("Erick");
//strNama.Add("Agus");
//strNama.Add("Joe");
//strNama.Add("Jojo");

//foreach (string nama in strNama)
//{
//    Console.WriteLine(nama);
//}

//enum Hari
//{
//    Senin = 1,
//    Selasa = 2,
//    Rabu = 3,
//    Kamis = 4,
//    Jumat = 5,
//    Sabtu = 6,
//    Minggu = 7
//}

//using RapidBootcamp.ConsoleApp;

//Console.Write("Masukan Jumlah Matakuliah: ");
//int jumlah = Convert.ToInt32(Console.ReadLine());

//List<double> lstScore = new List<double>();

//for (int i = 0; i < jumlah; i++)
//{
//    Console.Write($"Masukan Nilai Matakuliah {i + 1} (1-100) :");
//    lstScore.Add(Convert.ToDouble(Console.ReadLine()));
//}

//try
//{
//    double sumOfScore = 0;
//    foreach (double score in lstScore)
//    {
//        sumOfScore += score;
//    }

//    Stack<int> stackNumber = new Stack<int>();
//    stackNumber.Push(12);
//    stackNumber.Push(20);
//    stackNumber.Push(25);

//    Console.WriteLine(stackNumber.Pop());

//    Queue<int> queue = new Queue<int>();
//    queue.Enqueue(1);
//    queue.Enqueue(2);
//    queue.Enqueue(3);
//    queue.Enqueue(4);

//    Console.WriteLine(queue.Dequeue());

//    List<string> lstNames = new List<string>();
//    lstNames.Add("Erick");
//    lstNames.Add("Agus");

//    Console.WriteLine(lstNames[0]);

//    Dictionary<string, int> shoppingCart = new Dictionary<string, int>();
//    shoppingCart["P001"] = 2;
//    shoppingCart["K002"] = 3;


//    string gradeResult = CalculateGrade(sumOfScore);
//    Console.WriteLine($"Score: {sumOfScore} - Grade: {gradeResult}");

//    DisplayRandomNumbers();

//    //Helper myHelper = new Helper();
//    //double luasSegitiga = myHelper.HitungLuasSegitiga(10, 5);
//    //double luasPersegi = myHelper.HitungLuasPersegi(10);
//    double luasSegitiga = Helper.HitungLuasSegitiga(10, 5);
//    double luasPersegi = Helper.HitungLuasPersegi(10);
//    Console.WriteLine($"luas segitiga: {luasSegitiga}, luasPersegi: {luasPersegi}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"{ex.Message}");
//}

//string CalculateGrade(double score)
//{
//    string grade = string.Empty;
//    if (score >= 86 && score <= 100)
//    {
//        grade = "A";
//    }
//    else if (score >= 71 && score <= 85)
//    {
//        grade = "B";
//    }
//    else if (score >= 56 && score <= 70)
//    {
//        grade = "C";
//    }
//    else if (score >= 40 && score <= 55)
//    {
//        grade = "D";
//    }
//    else
//    {
//        grade = "E";
//    }
//    return grade;
//}

//void DisplayRandomNumbers()
//{
//    Random random = new Random();

//    for (int i = 0; i < 5; i++)
//    {
//        Console.Write($"{random.Next(1, 100)} ");
//    }
//}


//using RapidBootcamp.ConsoleApp.Domain;

//Student student1 = new Student();
//Student student2 = new Student();
//Student student3 = new Student("7778886543", "James");
//Student student4 = new Student("9966556654", "Affan", "Bandung");
//Student student5 = new Student
//{
//    Nim = "1122334455",
//    Name = "Budi",
//    Address = "Jakarta"
//};

//Lecturer lecturer1 = new Lecturer()
//{
//    LecturerId = 1,
//    LecturerName = "Joko",
//    Address = "Semarang"
//};
//Lecturer lecturer2 = new Lecturer(2, "Bams", "Jogja");

//student1.setNim("9988998899");
//student1.setName("Erick Kurniawan");
//try
//{
//    student1.Nim = "9988998899";
//    student1.Name = "Erick Kurniawan";
//    student1.Address = "Redmond WA";
//    Console.WriteLine(student1.Nim + "\n" + student1.Name + "\n" + student1.Address);
//    Console.WriteLine($"{student2.Nim}\n{student2.Name}\n{student2.Address}");
//    Console.WriteLine($"{student3.Nim}\n{student3.Name}\n{student3.Address}");
//    Console.WriteLine($"{student4.Nim}\n{student4.Name}\n{student4.Address}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error: {ex.Message}");
//}

//POCO
//List<Student> lstStudents = new List<Student>();

//Console.Write("Masukan Jumlah Student: ");
//int jumlah = Convert.ToInt32(Console.ReadLine());
//int counter = 0;
//while (counter < jumlah)
//{
//    Student newStudent = new Student();
//    Console.Write("Masukan Nim: ");
//    newStudent.Nim = Console.ReadLine();
//    Console.Write("Masukan Nama: ");
//    newStudent.Name = Console.ReadLine();
//    Console.Write("Masukan Address: ");
//    newStudent.Address = Console.ReadLine();

//    lstStudents.Add(newStudent);
//    counter++;
//}

//Console.WriteLine("=======================================================");
//Console.WriteLine("Nim\tNama\tAddress");
//foreach (Student student in lstStudents)
//{
//    Console.WriteLine($"{student.Nim} - {student.Name} - {student.Address}");
//}

using RapidBootcamp.ConsoleApp.DAL;
using RapidBootcamp.ConsoleApp.Domain;

//Person person1 = new Person();
//person1.FullName = "Muhammad Saefudin";
//person1.Address = "Jakarta";
//person1.PhoneNumber = "0882343212312312";
//Console.WriteLine(person1.GetInfo());

//Student student1 = new Student();
//student1.FullName = "Muh Apud";
//student1.Address = "Tangerang Selatan";
//student1.PhoneNumber = "087877806865";
//student1.Nim = "812736";
//student1.IPK = 3.89;
////Console.WriteLine(student1.GetInfo());
////Console.WriteLine($"Get IPK: {student1.GetIPK()}");

//Student student2 = new Student("Farhan", "Bangka Belitung", "0878778786565", "345876", 3.34);
//Console.WriteLine(student2.GetInfo());

//Student student3 = new Student("Surya", "Lampung", "087877878547", "456709", 3.45);

//Lecturer lecturer1 = new Lecturer();
//lecturer1.FullName = "Joko";
//lecturer1.Address = "Surabaya";
//lecturer1.PhoneNumber = "088097675435";
//lecturer1.NIK = "4012375689";
//lecturer1.RoomNumber = "B-401";
//Console.WriteLine(lecturer1.GetInfo());

//SecondYearStudent scstudent1 = new SecondYearStudent();
//scstudent1.FullName = "Satria Handanoko";
//scstudent1.Address = "Lampung";
//scstudent1.PhoneNumber = "088180809767";
//scstudent1.Nim = "21564798";
//scstudent1.IPK = 3.08;
//scstudent1.Major = "Information Technology";
//scstudent1.Class = "A-2";
//Console.WriteLine(scstudent1.GetInfo());

//List<Person> persons = new List<Person>();
//persons.Add(student1);
//persons.Add(student2);
//persons.Add(student3);
//persons.Add(lecturer1);
//persons.Add(scstudent1);

//foreach (Person person in persons)
//{
//    Console.WriteLine(person.GetInfo());
//}

//

//CategoriesDAL categoriesDAL = new CategoriesDAL();
//var categories = categoriesDAL.GetAll();

//Console.WriteLine("========================================================================");
//Console.WriteLine("Category ID\tCategory Name");
//foreach (var category in categories)
//{
//    Console.WriteLine($"{category.CategoryId.ToString().PadLeft(10)}\t{category.CategoryName.PadRight(30)}");
//}
//Console.WriteLine("========================================================================");

//

//CategoriesDAL categoriesDAL = new CategoriesDAL();
//try
//{
//    var categories = categoriesDAL.GetAll();

//    Console.WriteLine("========================================================================");
//    Console.WriteLine("Category ID\tCategory Name");
//    foreach (var category in categories)
//    {
//        Console.WriteLine($"{category.CategoryId.ToString().PadLeft(10)}\t{category.CategoryName.PadRight(30)}");
//    }
//    Console.WriteLine("========================================================================");

//    Console.Write("Cari Kategori? Masukkan ID: ");
//    int categoryId = Convert.ToInt32(Console.ReadLine());
//    Category resultCategory = categoriesDAL.GetById(categoryId);
//    if (resultCategory != null )
//    {
//        Console.WriteLine($"{resultCategory.CategoryId.ToString().PadLeft(10)}\t{resultCategory.CategoryName.PadRight(30)}");
//    }
//    else
//    {
//        Console.WriteLine("Data tidak ditemukan!");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Message Error: {ex.Message}");
//}

//

////Tambahan ketika masuk ke materi update data
//CategoriesDAL categoriesDAL = new CategoriesDAL();
//IEnumerable<Category> categories = new List<Category>();

//try
//{
//    /*var*/ categories = categoriesDAL.GetAll();

//    //Console.WriteLine("========================================================================");
//    //Console.WriteLine("Category ID\tCategory Name");
//    //foreach (var category in categories)
//    //{
//    //    Console.WriteLine($"{category.CategoryId.ToString().PadLeft(10)}\t{category.CategoryName.PadRight(30)}");
//    //}
//    //Console.WriteLine("========================================================================");

//    //Console.Write("Cari Kategori? Masukkan ID: ");
//    //int categoryId = Convert.ToInt32(Console.ReadLine());
//    //Category resultCategory = categoriesDAL.GetById(categoryId);
//    //if (resultCategory != null )
//    //{
//    //    Console.WriteLine($"{resultCategory.CategoryId.ToString().PadLeft(10)}\t{resultCategory.CategoryName.PadRight(30)}");
//    //}
//    //else
//    //{
//    //    Console.WriteLine("Data tidak ditemukan!");
//    //}

//    //DisplayAllData(categories);
//    //Console.Write("Tambah Kategori? Masukkan Nama Kategori Baru: ");
//    //string categoryName = Console.ReadLine();
//    //Category newCategory = new Category
//    //{
//    //    CategoryName = categoryName
//    //};
//    //Category result = categoriesDAL.Add(newCategory);
//    //if (result != null)
//    //{
//    //    Console.WriteLine("Data Category : {newCategory.CategoryId} - {newCategory.CategoryName} di simpan");
//    //}
//    //else
//    //{
//    //    Console.WriteLine("Data gagal disimpan");
//    //}

//    DisplayAllData(categories);
//    Console.Write("Ubah Kategori? Masukkan ID Kategori Yang akan diubah: ");
//    int categoryId = Convert.ToInt32(Console.ReadLine());

//    //Mendapatkan ID data yang akan di update
//    Category categoryToUpdate = categoriesDAL.GetById(categoryId);
//    if (categoryToUpdate != null )
//    {
//        Console.Write("Silahkan masukkan Nama Kategori: ");

//        categoryToUpdate.CategoryName = Console.ReadLine();
//        Category result = categoriesDAL.Update(categoryToUpdate);

//        if (result != null)
//        {
//            Console.WriteLine($"Data Category : {result.CategoryId} - {result.CategoryName} berhasil diupdate !");

//            categories = categoriesDAL.GetAll();
//            DisplayAllData(categories);
//        }
//        else
//        {
//            Console.WriteLine("Data gagal diupdate");
//        }
//    }
//    else
//    {
//        Console.WriteLine("Data tidak ditemukan");

//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error: {ex.Message}");
//}


//void DisplayAllData(IEnumerable<Category> categories)
//{
//    Console.WriteLine("========================================================================");
//    Console.WriteLine("CategoryId\tCategoryName");
//    foreach (Category category in categories)
//    {
//        Console.WriteLine($"{category.CategoryId.ToString().PadLeft(10)} {category.CategoryName.PadRight(30)}");
//    }
//    Console.WriteLine("========================================================================");
//}

//

//Tambahan ketika masuk ke materi update data
//CategoriesDAL categoriesDAL = new CategoriesDAL();
//IEnumerable<Category> categories = new List<Category>();

//try
//{
//    /*var*/
//    categories = categoriesDAL.GetAll();
//    DisplayAllData(categories);

//    Console.Write("Cari Kategori? Ketik disini yang ingin anda cari: ");
//    string categoryName = Console.ReadLine();
//    IEnumerable<Category> resultCategories = categoriesDAL.GetByCategoryName(categoryName);
//    if (resultCategories != null)
//    {
//        DisplayAllData(resultCategories);
//    }
//    else
//    {
//        Console.WriteLine("Data tidak ditemukan!");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error: {ex.Message}");
//}


//void DisplayAllData(IEnumerable<Category> categories)
//{
//    Console.WriteLine("========================================================================");
//    Console.WriteLine("CategoryId\tCategoryName");
//    foreach (Category category in categories)
//    {
//        Console.WriteLine($"{category.CategoryId.ToString().PadLeft(10)}\t{category.CategoryName.PadRight(30)}");
//    }
//    Console.WriteLine("========================================================================");
//}




// Product Category

//ProductsDAL productsDAL = new ProductsDAL();
//var products = productsDAL.GetAll();

//Console.WriteLine("========================================================================");
//Console.WriteLine("Category ID\tCategory Name");
//foreach (Product product in products)
//{
//    Console.WriteLine($"{product.ProductId.ToString().PadLeft(10)}\t{product.CategoryId.ToString().PadLeft(10)}\t{product.ProductName.PadRight(30)}");
//}
//Console.WriteLine("========================================================================");



//GetProductsWithCategory

//ProductsDAL productsDAL = new ProductsDAL();
//var products = productsDAL.GetProductsWithCategory();
//Console.WriteLine("\n\n=========================================================================================");
//Console.WriteLine("| Product ID\t| Category ID\t| Category Name\t| Product Name\t| Stock\t| Price\t\t|");
//Console.WriteLine("=========================================================================================");
//foreach (Product product in products)
//{
//    Console.WriteLine($"| {product.ProductId.ToString().PadLeft(10)}\t| {product.CategoryId.ToString().PadLeft(10)}\t| {product.Category.CategoryName.ToString().PadLeft(10)}\t| {product.ProductName.PadLeft(10)}\t| {product.Stock}\t| {string.Format("Rp{0:N0}", product.Price)}\t|");
//}
//Console.WriteLine("=========================================================================================\n\n\n\n\n\n\n");



//GetProductsWithCategory

ProductsDAL productsDAL = new ProductsDAL();
var products = productsDAL.GetProductsWithCategory();
Console.WriteLine("\n\n=========================================================================================");
Console.WriteLine("| Product ID\t| Category ID\t| Category Name\t| Product Name\t| Stock\t| Price\t\t|");
Console.WriteLine("=========================================================================================");
foreach (Product product in products)
{
    Console.WriteLine($"| {product.ProductId.ToString().PadLeft(10)}\t| {product.CategoryId.ToString().PadLeft(10)}\t| {product.Category.CategoryName.ToString().PadLeft(10)}\t| {product.ProductName.PadLeft(10)}\t| {product.Stock}\t| {string.Format("Rp{0:N0}", product.Price)}\t|");
}
Console.WriteLine("=========================================================================================\n\n\n\n\n\n\n");
