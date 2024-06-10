using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBootcamp.ConsoleApp.Domain
{
    public class Lecturer : Person
    {
        //public int LectureId { get; set; }
        //public string LectureName { get; set; }

        //private string lectureId = string.Empty;
        //public string LectureId
        //{ 
        //    get { return lectureId; }
        //    set 
        //    {
        //        if (value.Length != 10)
        //        {
        //            throw new Exception("Lecture ID harus berisi 10 karakter");
        //        }
        //        lectureId = value; 
        //    }
        //}

        //private string lectureName = string.Empty;
        //public string LectureName
        //{
        //    get { return lectureName; }
        //    set { lectureName = value; }
        //}

        //private string lectureAddress = string.Empty;
        //public string LectureAddress
        //{
        //    get { return lectureAddress; }
        //    set { lectureAddress = value; }
        //}

        //

        //public Lecturer()
        //{
        //    LecturerId = 1;
        //    LecturerName = "Budi";
        //    Address = "Jakarta";
        //}

        //public Lecturer(int lecturerId, string lecturerName, string address)
        //{
        //    this.LecturerId = lecturerId;
        //    this.LecturerName = lecturerName;
        //    this.Address = address;
        //}

        //public int LecturerId { get; set; }
        //public string LecturerName { get; set; }
        //public string Address { get; set; }

        public string? NIK { get; set; }
        public string? RoomNumber { get; set; }

        public override string GetFullName()
        {
            throw new NotImplementedException();
        }

        public override string GetInfo()
        {
            return $"Name: {FullName}, Address: {Address}, Phone: {PhoneNumber}, NIK: {NIK}, Room Number: {RoomNumber}";
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
