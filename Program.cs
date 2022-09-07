using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introduccion_a_ADO
{
    internal class Program
    {

       
        

        static void Main(string[] args)
        {
           
            int menu;
            do
            {
                Console.WriteLine(".....................Seleccinar la funcion de la tabla EstatusAlumno" +
                ".....................\n \n.....................1.-Consultar Todo" +
                "\n\n.....................2.-Consultar Solo Uno\n\n....................." +
                "3.-Agregar\n\n.....................4.-Actualizar" +
                "\n\n.....................5.-Eliminar\n\n.....................6.-Terminar");
                menu = int.Parse(Console.ReadLine());
                ADOEstatus ado = new ADOEstatus();

                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        
                        List<Estatus> lista = ado.ConsultarTodo();
                        foreach (Estatus estatus in lista)
                        {
                            Console.WriteLine($" [id]: {estatus.Id} [clave:] {estatus.Clave} [Nombre:] {estatus.Nombre}");
                        }
                       

                        break;
                    case 2:
                        Console.Clear();
                      
                        Console.WriteLine("Digite el is Abuscar");
                        int x = int.Parse(Console.ReadLine());
                        Estatus m = ado.Consultar(x);
                        Console.WriteLine($"[Clave:] {m.Clave} [Nombre:] {m.Nombre}");
                        break;
                    case 3:
                        Estatus propiedades = new Estatus();
                       

                        Console.WriteLine("Digite la clave");
                        propiedades.Clave=Console.ReadLine();

                        Console.WriteLine("Digite el nombre");
                        propiedades.Nombre = Console.ReadLine();

                       int retur = ado.Agregar(propiedades);
                        Console.WriteLine(retur);
                        
                   
                        break;
                    case 4:
                        Estatus propiedadesa = new Estatus();
                        Console.WriteLine("Digite el id a Actualizar");
                        propiedadesa.Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("digite la clave");
                        propiedadesa.Clave = Console.ReadLine();
                        Console.WriteLine("Digite el nombre");
                        propiedadesa.Nombre = Console.ReadLine();
                        ado.Actualizar(propiedadesa);
                   
       
                        break;
                    case 5:
                        Estatus p = new Estatus();
                        Console.WriteLine("Digitar el id del Registro a Eliminar");
                        int entero = int.Parse(Console.ReadLine());
                        ado.Eliminar(entero);
                    
                        break;
                  
                    default:
                        Console.WriteLine("Accion no realizada por el menu");
                        break;

                }



            } while (menu != 6);
            
        }
    }
    }


