
using System;
namespace project.Domain
{
    public class Office : Asset

     {

            public Office(string name)

            {

                Name = name;

            }


        public int OfficeId{ get; set; }
            public string Name { get; set; }

    }
 } 

 

 

 
