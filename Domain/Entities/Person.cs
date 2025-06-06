﻿using Domain.Enum;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public FullName? FullName { get; set; }
        public Email? Email { get; set; }
        public Password? Password { get; set; }
        public Identity? Identity { get; set; }
        public DateOfBirth? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public Phone? Phone { get; set; }
        public Address? Address { get; set; }
        public City? City { get; set; }
        public State? State { get; set; }
        public ZipCode? ZipCode { get; set; }
        public Country? Country { get; set; }
        public Roles? Role { get; set; }
        public bool IsActive { get; set; } = true;

        protected Person() { }

        public Person(FullName fullName, Email email, Password password, Identity identity, DateOfBirth dateOfBirth, Gender gender, Phone phone, Address address, City city, State state, ZipCode zipCode, Country country, Roles role, bool isActive)
        { 
            FullName = fullName;
            Email = email;
            Password = password;
            Identity = identity;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Phone = phone;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            Role = role;
            IsActive = isActive;
        }
    }
}
