using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBootcamp.ConsoleApp.Domain
{
    //public class Student
    //{
    //    //public string Name { get; set; }
    //    //public int Age { get; set; }

    //    //private string nim;
    //    //public void setNim(string nim)
    //    //{
    //    //    if (nim.Length != 10)
    //    //    {
    //    //        throw new Exception("NIM harus 10 karakter");
    //    //    }
    //    //    this.nim = nim;
    //    //}

    //    //public string getNim()
    //    //{
    //    //    return nim;
    //    //}

    //    private string nim = string.Empty;

    //    //object property
    //    public string Nim
    //    {
    //        get { return nim; }
    //        set
    //        {
    //            if (value.Length != 10)
    //            {
    //                throw new Exception("NIM harus 10 karakter");
    //            }
    //            nim = value;
    //        }
    //    }

    //    /*public void setNim(string nim)
    //    {
    //        if (nim.Length != 10)
    //        {
    //            throw new Exception("NIM harus 10 karakter");
    //        }
    //        this.nim = nim;
    //    }

    //    public string getNim()
    //    {
    //        return nim;
    //    }*/

    //    private string name = string.Empty;
    //    public string Name
    //    {
    //        get { return name; }
    //        set { name = value; }
    //    }
    //    /*public void setName(string name)
    //    {
    //        this.name = name;
    //    }

    //    public string getName()
    //    {
    //        return name;
    //    }*/

    //    private string address = string.Empty;
    //    public string Address
    //    {
    //        get { return address; }
    //        set { address = value; }
    //    }
    //}

    public class Student : Person
    {
        public Student() { }

        public Student(string fullname, string address, string phonenumber, string nim, double ipk) : base(fullname, address, phonenumber)
        {
            this.Nim = nim;
            this.IPK = ipk;
        }

        public string? Nim {  get; set; }
        public double IPK { get; set; }

        public double GetIPK()
        {
            return IPK;
        }

        public override string GetInfo()
        {
            return $"Name: {FullName}, Address: {Address}, Phone: {PhoneNumber}, Nim: {Nim}, IPK: {IPK}";
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override string GetFullName()
        {
            throw new NotImplementedException();
        }
    }
}
