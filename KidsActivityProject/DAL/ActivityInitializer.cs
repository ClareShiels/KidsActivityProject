using System;
using System.Collections.Generic;
using KidsActivityProject.Models;

namespace KidsActivityProject.DAL
{
    public class ActivityInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ActivityContext>
    {
        protected override void Seed(ActivityContext context)
        {
            //Populate Child table
            var children = new List<Kid>
                {
                    new Kid {FirstName="Cathal",LastName="O'Sullivan",Address="14 Prospect Grove, Rathfarnham, Dublin 16",DOB=DateTime.Parse("2004-12-15"), MedicalIssues=Medical.no, MedicalIntervention=FirstAid.yes, GuardianFirstName="Gary", GuardianLastName="O'Sullivan",GuardianContactNumber="+353871111111",ContactEmail="garyosullivan@gmail.com" },
                    new Kid {FirstName="Cillian",LastName="O'Brien",Address="23 College Drive, Terenure, Dublin 6W",DOB=DateTime.Parse("2000-10-09"), MedicalIssues=Medical.yes, MedicalIntervention=FirstAid.yes, GuardianFirstName="Fiona", GuardianLastName="O'Brien",GuardianContactNumber="+353872222222",ContactEmail="fionaobrien@hotmail.com" },
                    new Kid {FirstName="Maeve",LastName="McDonagh",Address="12 Fosterbrook, Stillorgan, Co Dublin",DOB=DateTime.Parse("1998-06-06"), MedicalIssues=Medical.no, MedicalIntervention=FirstAid.yes, GuardianFirstName="Mark", GuardianLastName="McDonagh",GuardianContactNumber="+353853333333",ContactEmail="markmcdonagh@gmail.com" }
                };

            children.ForEach(c => context.Kids.Add(c));
            context.SaveChanges();
        }
        //Populate Activity table
        //Populate Enrollment table
    }
}
