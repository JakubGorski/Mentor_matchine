﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mentor_Matchine.Models.MatcherLogic
{
    public class MentorUser:User
    {
        private string _name;
        private string _surname;
        private int _age;
        private string _email;
        private string _gender;
        private byte _disability;
        private List<int> _languages;

        public MentorUser(string name, string surname, string email, string gender, byte disability, int mentees)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _gender = gender;
            _disability = disability;
            Mentees = mentees;
        }
        public List<int> PrefNationalities { get; set; }
        public System.DateTime StartDate { get; set; }

        public int Mentees { get; set; }

        public override List<int> Languages
        {
            get { return _languages; }
            set { _languages = value; }
        }

        public override string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override string Surame
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public override string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public override int Age
        {
            get { return _age; }
            set { Age = value; }
        }

        public override string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public override byte Disability
        {
            get { return _disability; }
            set { _disability = value; }
        }
    }
}