
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
            // En GET request d�r alla studenter i databasen h�mtas
            //---------------------------------------------------------------------
            app.MapGet("/index", (NEWSchool2DBContext context) =>
            {
                var AllStudents = context.Studens;

                return AllStudents;
            });
            //---------------------------------------------------------------------
            // En POST request d�r en studen l�ggs till i databasen
            //---------------------------------------------------------------------
            app.MapPost("/students", (Student student, NEWSchool2DBContext context) =>
            {
                context.Studens.Add(student);
                context.SaveChanges();

                return student;
            });
            //---------------------------------------------------------------------
            // En GET request d�r en SPECIFIK student h�mtas fr�n databasen (vi ID)
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
            // En DELETE request d�r en student tas bort fr�n databasen
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
            // En PUT request d�r en students data �ndras i databasen
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
    //          .FirstOrDefault  returnar f�rsta valuet den hittar som matchar en kriteria, annars returnar den null eller 0 beroende p� datatyp (string, int)
    //          .count()         returnar ett numer (det g�r att l�gga till "qriteria f�r vad den ska r�kna)
    //          .any()           returnar true om det finns n�got
    //
    ////-------------------------------------------------------------------------------------------------------------------------
    //
    //         * Den h�r lektionen handlar om WEB-API's, Http requests och Crud Operations (GET, POST, PUT, DELETE) *
    //
    //           API - Aplication Programming interface: en Aplikation/kod som matchar data fr�n ett system till ett annat program
    //                 och agerar som en interface f�r att programet ska kunna ta emot och anv�nda sig av datan.
    //                 AKA att datan tas emot i ett format (oftast .JSON) som programmet kan l�sa av, som en nykel i ett l�s.
    //
    //                 En av dom vanligaste API typerna �r en s� kallad WEB-API, det �r n�r datan h�mtas via ett https protokol
    //                 vanligtsvis fr�n en server eller databas, och oftast i .JSON format. som ett exempel h�mtas data via ett
    //                 https protokol n�r man laddar en hemsida via sin webl�sare. datan k�rs via ett program som sedan displayar
    //                 hemsidan.
    //                 Beroende p� om man h�mtar, skickar, uppdaterar eller deletar data via API'n s� anv�nder man olika metoder
    //                 som kallas CRUD operations
    //
    //          CRUD - Vanliga CRUD operations:
    //          
    //                 GET:    f�r att h�mta l�sa data fr�n servern/databasen
    //                 POST:   f�r att skicka data till servern/databasen
    //                 PUT:    f�r att uppdatera/�ndra data i servern/databasen
    //                 DELETE: f�r att ta bort data fr�n Servern/databasen
    //
    //  
    //       ASP.NET - ett f�rdigt .NET WEB-API framework f�r att skappa hemsidor och g�ra CRUD operationer via https protokol,
    //                 mer specifikt mot databaser och via Entity Framework
    //                 
    //                 app.MapGet()      - f�rdig metod inom ASP.NET f�r att g�ra GET requests
    //                 app.MapPost()     - f�rdig metod inom ASP.NET f�r att g�ra POST requests
    //                 app.MapDelete()   - f�rdig metod inom ASP.NET f�r att g�ra DELETE requests
    //                 app.MapPut()      - f�rdig metod inom ASP.NET f�r att g�ra PUT requests
    //
    //                 Alla ovanf�r n�mda metoder anv�nds i koden som k�rs i main, s� om du vill se exempel p� syntax
    //                 och hur dom anv�nds kolla d�r.
    //
    //
}
