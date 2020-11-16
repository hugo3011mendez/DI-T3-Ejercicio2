using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Ejercicio
    {
        static void Main(string[] args)
        {
            Aula aula = new Aula();
            aula.rellenarTabla();

            bool repetir = true;
            while (repetir)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1 - Calcular la media de notas de toda la tabla");
                Console.WriteLine("2 - Media de un alumno");
                Console.WriteLine("3 - Media de una asignatura");
                Console.WriteLine("4 - Visualizar notas de un alumno");
                Console.WriteLine("5 - Visualizar notas de una asignatura");
                Console.WriteLine("6 - Nota máxima y mínima de un alumno");
                Console.WriteLine("7 - Tabla solo de aprobados");
                Console.WriteLine("8 - Visualizar tabla completa");
                Console.WriteLine("9 - Salir");
                Console.WriteLine();
                Console.WriteLine("Qué quieres hacer?");
                try
                {
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    int alumno, materia;

                    switch (opcion)
                    {
                        case 1:
                            aula.calcularMediaTotal();
                            Console.WriteLine();
                            Console.WriteLine("Pulsa Enter para continuar");
                            Console.ReadLine();
                            break;

                        case 2:
                            Console.WriteLine("Introduce el índice del alumno sobre el que quieres ver la media : ");
                            alumno = Convert.ToInt32(Console.ReadLine());
                            aula.calcularMediaAlumno(alumno);
                            Console.WriteLine();
                            Console.WriteLine("Pulsa Enter para continuar");
                            Console.ReadLine();
                            break;

                        case 3:
                            Console.WriteLine("Introduce el índice de la materia sobre la que quieres ver la media : ");
                            materia = Convert.ToInt32(Console.ReadLine());
                            aula.calcularMediaAsignatura(materia);
                            Console.WriteLine();
                            Console.WriteLine("Pulsa Enter para continuar");
                            Console.ReadLine();
                            break;

                        case 4:
                            Console.WriteLine("Introduce el índice del alumno sobre el que quieres sus notas : ");
                            alumno = Convert.ToInt32(Console.ReadLine());
                            aula.verNotasAlumno(alumno);
                            Console.WriteLine();
                            Console.WriteLine("Pulsa enter para continuar");
                            Console.ReadLine();
                            break;

                        case 5:
                            Console.WriteLine("Introduce el índice de la materia sobre la que quieres ver sus notas : ");
                            materia = Convert.ToInt32(Console.ReadLine());
                            aula.verNotasAsignatura(materia);
                            Console.WriteLine();
                            Console.WriteLine("Pulsa enter para continuar");
                            Console.ReadLine();
                            break;

                        case 6:
                            Console.WriteLine("Introduce el índice del alumno sobre el que quieres ver la nota más baja y la más alta : ");
                            alumno = Convert.ToInt32(Console.ReadLine());
                            aula.notaMaxMinAlumno(alumno);
                            Console.WriteLine();
                            Console.WriteLine("Pulsa Enter para continuar");
                            Console.ReadLine();
                            break;

                        case 7:
                            aula.tablaAprobados();
                            Console.WriteLine();
                            Console.WriteLine("Pulsa Enter para continuar");
                            Console.ReadLine();
                            break;

                        case 8:
                            aula.verTabla();
                            break;

                        case 9:
                            repetir = false;
                            Console.WriteLine("Hasta luego!");
                            break;

                        default:
                            Console.WriteLine("No existe esa opción, repite");
                            break;
                    }
                }
                catch (Exception e)
                {
                    if (e is OverflowException || e is FormatException || e is NullReferenceException || e is IndexOutOfRangeException)
                    {
                        Console.WriteLine("Ha ocurrido un error en escribir el dato, asegúrate de que lo escribes bien");
                    }
                }
            }

        }
    }
}
