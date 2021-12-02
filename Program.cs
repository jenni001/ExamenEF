using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static System.Console;


public class InstitutoContext : DbContext
{
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Modulo> Modulos { get; set; }
    public DbSet<Matricula> Matriculas { get; set; }

    public string connString { get; private set; }

    public InstitutoContext()
    {
        var database = "EF03Jennifer"; // "EF{XX}Nombre" => EF00Santi
        connString = $"Server=185.60.40.210\\SQLEXPRESS,58015;Database={database};User Id=sa;Password=Pa88word;MultipleActiveResultSets=true";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(connString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Matricula>().HasIndex(m => new
                {
                    m.AlumnoId,
                    m.ModuloId
                }).IsUnique();
    }
}
public class Alumno
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int AlumnoId { get; set; }

    public string Nombre {get;set;}
    public int Edad {get;set;}
    public int Efectivo {get;set;}
    public string Pelo {get;set;}
    public List<Matricula> Matriculacion { get; } = new List<Matricula>();

}
public class Modulo
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ModuloId { get; set; }

    public string Titulo {get; set;}

    public int Creditos {get;set;}
    public int Curso {get;set;}

    public List<Matricula> Matriculado { get; } = new List<Matricula>();
}
public class Matricula
{

    public int MatriculaId{ get; set; }

    [ForeignKey("Alumno")]
    public int ModuloId { get; set; } 

    [ForeignKey("Modulo")]
    public int AlumnoId { get; set; } 

}

class Program
{
    static void GenerarDatos()
    {
        using (var db = new InstitutoContext())
        {
            // Borrar todo

            //Console.WriteLine("Borro");
           /* db.Alumnos.RemoveRange(db.Alumnos);
            db.Modulos.RemoveRange(db.Modulos);
            db.Matriculas.RemoveRange(db.Matriculas);
            db.SaveChanges();
            

            // Añadir Alumnos
            // Id de 1 a 7

            Console.WriteLine("Introduzco alumnos");
            db.Alumnos.Add(new Alumno { AlumnoId = 1 , Nombre = "Martina", Edad = 11, Efectivo = 23, Pelo="rubio"});
            db.Alumnos.Add(new Alumno { AlumnoId = 2 , Nombre = "Emma", Edad = 52, Efectivo = 350, Pelo="moreno"});
            db.Alumnos.Add(new Alumno { AlumnoId = 3 , Nombre = "Maria", Edad = 85, Efectivo = 52, Pelo="castaño" });
            db.Alumnos.Add(new Alumno { AlumnoId = 4 , Nombre = "Mikel", Edad = 31, Efectivo = 123, Pelo="rubio" });
            db.Alumnos.Add(new Alumno { AlumnoId = 5 , Nombre = "Iker", Edad = 56, Efectivo = 83, Pelo="rubio" });
            db.Alumnos.Add(new Alumno { AlumnoId = 6 , Nombre = "Jose", Edad = 85, Efectivo = 563, Pelo="castaño" });
            db.Alumnos.Add(new Alumno { AlumnoId = 7 , Nombre = "Vicente", Edad = 18, Efectivo = 0, Pelo="moreno" });
            db.SaveChanges();

        

            // Añadir Módulos
            // Id de 1 a 10

            Console.WriteLine("Introduzco Módulos");
            db.Modulos.Add(new Modulo { ModuloId = 1 , Titulo = "Lengua", Creditos=13, Curso= 1});
            db.Modulos.Add(new Modulo { ModuloId = 2 , Titulo = "Euskera", Creditos=3, Curso= 1 });
            db.Modulos.Add(new Modulo { ModuloId = 3 , Titulo = "Ingles", Creditos=80, Curso= 1 });
            db.Modulos.Add(new Modulo { ModuloId = 4 , Titulo = "Frances", Creditos=95, Curso= 1 });
            db.Modulos.Add(new Modulo { ModuloId = 5 , Titulo = "Matematicas", Creditos=1, Curso= 1 });
            db.Modulos.Add(new Modulo { ModuloId = 6 , Titulo = "Informatica", Creditos=8, Curso= 2 });
            db.Modulos.Add(new Modulo { ModuloId = 7 , Titulo = "Economia", Creditos=2, Curso= 2 });
            db.Modulos.Add(new Modulo { ModuloId = 8 , Titulo = "Fisica", Creditos=9, Curso= 2});
            db.Modulos.Add(new Modulo { ModuloId = 9 , Titulo = "Tecnologia", Creditos=5, Curso= 2 });
            db.Modulos.Add(new Modulo { ModuloId = 10 , Titulo = "Biologia", Creditos=5, Curso= 2 });
            db.SaveChanges();

            // Matricular Alumnos en Módulos
            var alumno = db.Alumnos.OrderBy(a => a.AlumnoId);
            var modulo = db.Modulos.OrderBy(m => m.ModuloId);
            Console.WriteLine("Introduzco Matricula");
            db.Matriculas.Add(new Matricula{AlumnoId=1, ModuloId=1});
            db.Matriculas.Add(new Matricula{AlumnoId=2, ModuloId=2});
            db.Matriculas.Add(new Matricula{AlumnoId=3, ModuloId=3});
            db.Matriculas.Add(new Matricula{AlumnoId=4, ModuloId=4});
            db.Matriculas.Add(new Matricula{AlumnoId=5, ModuloId=5});
            db.Matriculas.Add(new Matricula{AlumnoId=6, ModuloId=6});
            db.Matriculas.Add(new Matricula{AlumnoId=7, ModuloId=7});
            db.SaveChanges();
            Console.WriteLine("Introduzco Matricula extra");
            db.Matriculas.Add(new Matricula{AlumnoId=7, ModuloId=8});
            db.SaveChanges();*/
        }
    }

    static void BorrarMatriculaciones()
    {
        // Borrar las matriculas d
        // AlumnoId multiplo de 3 y ModuloId Multiplo de 2;
        // AlumnoId multiplo de 2 y ModuloId Multiplo de 5;


      /*using (var db = new InstitutoContext())
        {
           var matriculas = db.Matriculas;
            foreach(var element in matriculas){ 
                if (element.AlumnoId % 3 == 0 && element.AlumnoId % 2 == 0) {
                    Console.WriteLine(element.AlumnoId);
                    db.Matriculas.Remove(element);
                } 
                if (element.AlumnoId % 2 == 0 && element.AlumnoId % 5 == 0) {
                    Console.WriteLine(element.AlumnoId);
                    db.Matriculas.Remove(element);
                } 

            }
            db.SaveChanges();  
        }*/
    }
    static void RealizarQuery()
    {
        using (var db = new InstitutoContext())
        {
            // Las queries que se piden en el examen

            var col = db.Alumnos.Where(o => o.Pelo == "Rubio");
            Console.WriteLine("ejemplo 1 --> ");
             foreach (var lista in col)
            {
                Console.WriteLine( lista.Nombre);
            }
            
            var col2 = db.Modulos.Select(o => new
            {
                ModuloId = o.ModuloId,
                Curso = o.Curso
                }
            );
            Console.WriteLine("ejemplo 2 --> ");
             foreach (var lista in col2 )
            {
                Console.WriteLine(lista.ModuloId);
            }
           
            var col3 = db.Alumnos.OrderBy(o => o.Efectivo);
                        Console.WriteLine("ejemplo 3 --> ");
            foreach (var lista in col3)
            {
                Console.WriteLine(lista.Nombre);
            }
            var col4 = db.Alumnos.OrderByDescending(o => o.Efectivo);
                        Console.WriteLine("ejemplo 4 --> ");
            foreach (var lista in col4)
            {
                Console.WriteLine(lista.Nombre);
            }

            var col5 = db.Alumnos.OrderBy(o => o.Edad).
            ThenByDescending(o => o.Efectivo);
             Console.WriteLine("ejemplo 5--> ");
            foreach (var lista in col5)
            {
                Console.WriteLine(lista.Nombre);
            }
            
            var col6 = db.Alumnos.Join(db.Alumnos,
            c => c.Edad, o => o.Edad,
            (c, o) => new
            {
                c.Edad,
                c.Nombre,
                o.Efectivo,
                o.Pelo
            }
            );
            Console.WriteLine("ejemplo 6--> ");
            foreach (var lista in col6)
            {
                Console.WriteLine(lista.Nombre);
            }
            
            var col7= db.Modulos.GroupBy(
            o => o.Curso).
            Select(g => new
            {
            Curso = g.Key,
            TotalOrders = g.Count()
            });
            Console.WriteLine("ejemplo 7--> ");
            foreach (var lista in col7)
            {
                Console.WriteLine(lista.Curso );
            }

            var col8 = (from o in db.Modulos
            where o.Curso == 1
            select o).Take(3);
            Console.WriteLine("ejemplo 8--> ");
            foreach (var lista in col8)
            {
                Console.WriteLine(lista.Titulo );
            }

            var col9 = (from o in db.Modulos
            where o.Curso == 1
            orderby o.Creditos
            select o).Skip(2).Take(2);
            Console.WriteLine("ejemplo 9--> ");
            foreach (var lista in col9)
            {
                Console.WriteLine(lista.Titulo );
            }

            /*var col10 = db.Alumnos.Single(
            c => c.Edad == 18);

            Console.WriteLine("ejemplo 10--> ");
            foreach (var lista in col10)
            {
                Console.WriteLine(lista.Nombre);
            }*/


           string[] names = (from c in db.Alumnos
                select c.Nombre).ToArray();

            Console.WriteLine("to array--> ");
            foreach (var lista in names)
            {
                Console.WriteLine(lista);
            }

            /*Dictionary<int, Alumno> dic = db.Alumnos.ToDictionary(c => c.Edad);
            Dictionary<string, double> customerOrdersWithMaxCost = (from oc in
            (from o in db.Alumnos
            join c in db.Alumnos on o.Edad equals c.Edad
            select new { c.Nombre, o.Edad })
            group oc by oc.Nombre into g
            select g).ToDictionary(g => g.Key, g => g.Max(oc => oc.Nombre));*/

          /* List<Alumno> ordersOver10 = (from o in db.Alumnos
            where o.Efectivo > 10
            orderby o.Edad).ToList();*/


            ILookup<int, string> modulosLrookup =
            db.Modulos.ToLookup(c => c.ModuloId, c => c.Titulo);

            Console.WriteLine("toLookup--> ");
            





        }
    }

    static void Main(string[] args)
    {
        GenerarDatos();
        BorrarMatriculaciones();
        RealizarQuery();
    }

}