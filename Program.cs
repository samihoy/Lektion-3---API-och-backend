
using Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Data;
using Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models;
using Microsoft.EntityFrameworkCore;

namespace Lektion_3___Code_first_Databas_POST__GET__DELETE_etc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<NEWSchool2DBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //---------------------------------------------------------------------
            // En GET request där alla studenter i databasen hämtas
            //---------------------------------------------------------------------
            app.MapGet("/index", (NEWSchool2DBContext context) =>
            {
                var AllStudents = context.Studens;

                return AllStudents;
            });
            //---------------------------------------------------------------------
            // En POST request där en studen läggs till i databasen
            //---------------------------------------------------------------------
            app.MapPost("/students", (Student student, NEWSchool2DBContext context) =>
            {
                context.Studens.Add(student);
                context.SaveChanges();

                return student;
            });
            //---------------------------------------------------------------------
            // En GET request där en SPECIFIK student hämtas från databasen (vi ID)
            //---------------------------------------------------------------------
            app.MapGet("/students{id}",(NEWSchool2DBContext context, int id) =>
            {
                var student = context.Studens.FirstOrDefault(e => e.ID==id);

                if (student==null)
                {
                    return Results.NotFound("Student not found");
                }
                return Results.Ok(student);
            });
            //---------------------------------------------------------------------
            // En DELETE request där en student tas bort från databasen
            //---------------------------------------------------------------------
            app.MapDelete("/students{id}", (NEWSchool2DBContext context, int id) =>
            {
                var student = context.Studens.FirstOrDefault(e=> e.ID==id);
                if(student==null)
                {
                    return Results.NotFound("404 student not found");
                }
                context.Studens.Remove(student);
                context.SaveChanges();

                return Results.Ok("student deleted");
            });
            //-------------------------------------------------------------------
            // En PUT request där en students data ändras i databasen
            //-------------------------------------------------------------------
            app.MapPut("/students{id}",(NEWSchool2DBContext context, int id, Student student )=>
            {
                var UpdateStudent = context.Studens.FirstOrDefault(e => e.ID == id);

                if (UpdateStudent==null)
                {
                    return Results.NotFound("student not found");
                }
                UpdateStudent.Name = student.Name;
                UpdateStudent.Email = student.Email;
                UpdateStudent.Class = student.Class;

                context.SaveChanges();
                return Results.Ok("student updated");
            });


            app.Run();
        }
    }
    //-------------------------------------------------------------------------------------------------------------------------
    //                                           Antekningar
    //-------------------------------------------------------------------------------------------------------------------------
    //           LING
    //
    //          .Where           (e=>e.namn == "anna")
    //          .FirstOrDefault  returnar första valuet den hittar som matchar en kriteria, annars returnar den null eller 0 beroende på datatyp (string, int)
    //          .count()         returnar ett numer (det går att lägga till "qriteria för vad den ska räkna)
    //          .any()           returnar true om det finns något
    //
    ////-------------------------------------------------------------------------------------------------------------------------
    //
    //         * Den här lektionen handlar om WEB-API's, Http requests och Crud Operations (GET, POST, PUT, DELETE) *
    //
    //           API - Aplication Programming interface: en Aplikation/kod som matchar data från ett system till ett annat program
    //                 och agerar som en interface för att programet ska kunna ta emot och använda sig av datan.
    //                 AKA att datan tas emot i ett format (oftast .JSON) som programmet kan läsa av, som en nykel i ett lås.
    //
    //                 En av dom vanligaste API typerna är en så kallad WEB-API, det är när datan hämtas via ett https protokol
    //                 vanligtsvis från en server eller databas, och oftast i .JSON format. som ett exempel hämtas data via ett
    //                 https protokol när man laddar en hemsida via sin webläsare. datan körs via ett program som sedan displayar
    //                 hemsidan.
    //                 Beroende på om man hämtar, skickar, uppdaterar eller deletar data via API'n så använder man olika metoder
    //                 som kallas CRUD operations
    //
    //          CRUD - Vanliga CRUD operations:
    //          
    //                 GET:    för att hämta läsa data från servern/databasen
    //                 POST:   för att skicka data till servern/databasen
    //                 PUT:    för att uppdatera/ändra data i servern/databasen
    //                 DELETE: för att ta bort data från Servern/databasen
    //
    //  
    //       ASP.NET - ett färdigt .NET WEB-API framework för att skappa hemsidor och göra CRUD operationer via https protokol,
    //                 mer specifikt mot databaser och via Entity Framework
    //                 
    //                 app.MapGet()      - färdig metod inom ASP.NET för att göra GET requests
    //                 app.MapPost()     - färdig metod inom ASP.NET för att göra POST requests
    //                 app.MapDelete()   - färdig metod inom ASP.NET för att göra DELETE requests
    //                 app.MapPut()      - färdig metod inom ASP.NET för att göra PUT requests
    //
    //                 Alla ovanför nämda metoder används i koden som körs i main, så om du vill se exempel på syntax
    //                 och hur dom används kolla där.
    //
    //
}
