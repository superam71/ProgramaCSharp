using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lolaahhh
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack miPila = new Stack();

            List<string> lista=new List<string>();

            int opcion;//opcion del menu            

            do
            {
                Console.Clear();//se limpia consola
                opcion = menu();//muestra menu y espera opciónf

                switch (opcion)
                {
                    case 1:
                        agregar1(ref miPila);
                        break;
                    case 2:
                        eliminar(ref miPila,ref lista);
                        break;
                    case 3:
                        modificar(ref miPila,ref lista);
                        break;
                    case 4:
                        limpiar(ref miPila);
                        break;
                    case 5:
                        imprimir(miPila);
                        break;
                    case 6:
                        cantidadpatentes(miPila);
                        break;
                    case 7:
                        ultimapatente(miPila);
                        break;
                    case 8:
                        primerapatente(miPila);
                        break;
                    case 9:
                        buscarpatente(miPila);
                        break;
                    case 0:
                        break;
                    default:
                        mensaje("ERROR: la opción no es valida. Intente de nuevo.");
                        break;
                }

            }
            while (opcion != 0);
        }

        /** añade un nuevo elemento a la pila */
        static void agregar1(ref Stack miPila)
        {
            Console.Write("\n>Ingrese patente ejem:ZSQ 354 ");
            string valor = Console.ReadLine();
            if (valor.Length>7 || valor.Length<7) //
            {
                mensaje("Solo patentes de 6 digitos y 1 espacio");
            }
            else
            {
                try
                {
                    char separator=' ';
                    string [] separacion=valor.Split(separator);//es una lista de string
                    bool result = separacion[0].All(Char.IsLetter);//verificacion de que se pueda pasar a letras, si no se puede entonces el string no contiene letras
                    bool result2=separacion[0].All(Char.IsUpper);//verificacion de que las letras sean mayusculas
                    if(result==false)
                    {
                        mensaje("Introduce 3 letras mayusculas, un espacio y 3 numeros");
                    }
                    else if(result2==false)
                    {
                        mensaje("Introduce 3 letras mayusculas, un espacio y 3 numeros");
                    }
                    else
                    {
                        int patentepos2=Convert.ToInt32(separacion[1]); //verificacion de que se pueda pasar a entero, si no se puede entonces son letras
                        miPila.Push(valor);
                        mensaje("Elemento Guardado");
                    }
                }
                catch(FormatException)
                {
                    mensaje("Introduce 3 letras mayusculas, un espacio y 3 numeros");
                }
            }
        }
        /** Elimina todo los elementos de la pila */
        static void limpiar(ref Stack miPila)
        {
            miPila.Clear();
            imprimir(miPila);
        }

        /** Elimina elemento de la pila */
        static void eliminar(ref Stack miPila,ref List<string> lista)
        {
            if (miPila.Count > 0)
            {
                Console.Write("\n>Ingrese patente: ejem:ZSQ 354");
                string valor=Console.ReadLine();
                if (valor.Length>7 || valor.Length<7)
                {
                    mensaje("Solo patentes de 6 digitos y 1 espacio");
                }
                else
                {
                    try
                    {
                        foreach (string dato in miPila)
                        {
                            lista.Add(dato);
                        }
                        char separator=' ';
                        string [] separacion=valor.Split(separator);//es una lista de string
                        bool result = separacion[0].All(Char.IsLetter);//verificacion de que se pueda pasar a letras, si no se puede entonces el string no contiene letras
                        bool result2 = separacion[0].All(Char.IsUpper);//verificacion de que sean mayusculas
                        if(result==false)
                        {
                            mensaje("Introduce 3 letras mayusculas, un espacio y 3 numeros");
                        }
                        else if(result2==false)
                        {
                            mensaje("Introduce 3 letras mayusculas, un espacio y 3 numeros");
                        }
                        else
                        {
                            int patentepos2=Convert.ToInt32(separacion[1]);//verificacion de que se pueda pasar a entero, si no se puede entonces son letras
                            string patentepos2string=separacion[1];
                            if (miPila.Contains(valor))
                            {
                                int datopos=lista.IndexOf(valor);
                                string elemento=lista.ElementAt(datopos);
                                lista.Remove(elemento);
                                miPila.Clear();
                                foreach (string i in lista)
                                {
                                    miPila.Push(i);
                                }
                                lista.Clear();
                                mensaje("Elemento "+valor+" eliminado");
                            }
                            else
                            {
                                lista.Clear();
                                mensaje("Elemento no encontrado");
                            }
                        }
                    }
                    catch(FormatException)
                    {
                        mensaje("Introduce 3 letras mayusculas, un espacio y 3 numeros");
                    }
                }
            }
            else
            {
                mensaje("La Pila esta vacia");
            }
        }

        /** muestra menu y retorna opción */
        static int menu()
        {
            //Console.Clear();
            Console.WriteLine("\n            Stack Menu\n");
            Console.WriteLine("      1.- Agregar patente");
            Console.WriteLine("      2.- Eliminar patente");
            Console.WriteLine("      3.- Modificar patente");
            Console.WriteLine("      4.- Vaciar pila");
            Console.WriteLine("      5.- Ver pila");
            Console.WriteLine("      6.- Cantidad de patentes");
            Console.WriteLine("      7.- Ultima patente");
            Console.WriteLine("      8.- Primera patente");
            Console.WriteLine("      9.- Buscar patente");
            Console.WriteLine("      0.- Terminar programa");
            Console.Write("       Ingresa tu opción: ");
            try
            {
                int valor = Convert.ToInt32(Console.ReadLine());
                return valor;
            }
            catch
            {
                return 0;
            }
        }

        /** Muestra mensaje del programa al usuario */
        static void mensaje(String texto)
        {
            if (texto.Length > 0)
            {
                Console.WriteLine("\n    =======================================================");
                Console.WriteLine("    > {0}", texto);
                Console.WriteLine("    =======================================================");
                Enter();
            }
        }

        /** Imprime pila */
        static void imprimir(Stack miPila)
        {
            if (miPila.Count > 0)
            {
                Console.WriteLine("");
                foreach (string dato in miPila)
                {
                    Console.WriteLine("    |           |");
                    if (dato.Length< 1000000)
                        Console.WriteLine("    |  {0}  |", dato);
                    else
                        Console.WriteLine("    |  {0}  |", dato);
                    Console.WriteLine("    |___________|");
                }
                Enter();
            }
            else
            {
                mensaje("La Pila esta vacia");
            }
        }

        static void cantidadpatentes(Stack miPila)
        {
            int cantidadpatentes=miPila.Count;
            mensaje("La cantidad de patentes es "+cantidadpatentes);
        }

        static void ultimapatente(Stack miPila)
        {
            int contador=0;
            if (miPila.Count > 0)
            {
                foreach (string dato in miPila)
                {
                    contador=++contador;
                    if (contador==1)
                    {
                        Console.WriteLine("    |           |");
                        Console.WriteLine("    |  {0}  |", dato);
                        Console.WriteLine("    |___________|");
                    }
                    else if (contador>1)
                    {
                        Enter();
                        break;
                    }
                }
            }
            else
            {
                mensaje("La Pila esta vacia");
            }
        }

        static void primerapatente(Stack miPila)
        {
            int contador=0;
            if (miPila.Count > 0)
            {
                foreach (string dato in miPila)
                {
                    contador=++contador;
                    if (contador==miPila.Count)
                    {
                        Console.WriteLine("    |           |");
                        Console.WriteLine("    |  {0}  |", dato);
                        Console.WriteLine("    |___________|");
                        Enter();
                    }
                }
            }
            else
            {
                mensaje("La Pila esta vacia");
            }
        }

        static void modificar(ref Stack miPila,ref List<string> lista)
        {
            if (miPila.Count > 0)
            {
                Console.Write("\n>Ingrese patente a modificar, ejem:ZSQ 354");
                string valor=Console.ReadLine();
                Console.WriteLine("\n>Ingrese nuevo valor de la patente");
                string nuevovalor=Console.ReadLine();
                if (valor.Length>7 || valor.Length<7)
                {
                    mensaje("Solo patentes de 6 digitos y 1 espacio");
                }
                else
                {
                    if (nuevovalor.Length>7 || nuevovalor.Length<7)
                    {
                        mensaje("Solo patentes de 6 digitos y 1 espacio");
                    }
                    else
                    {
                        try
                        {
                            foreach (string dato in miPila)
                            {
                                lista.Add(dato);
                            }
                            char separator=' ';
                            string [] separacion=valor.Split(separator);//es una lista de string
                            bool result = separacion[0].All(Char.IsLetter);//verificacion de que se pueda pasar a letras, si no se puede entonces el string no contiene letras
                            bool result2=separacion[0].All(Char.IsUpper);//verificacion de que sean mayusculas
                            if(result==false)
                            {
                                mensaje("Introduce 3 letras mayusculas, un espacio y 3 numeros");
                            }
                            else if(result2==false)
                            {
                                mensaje("Introduce 3 letras mayusculas, un espacio y 3 numeros");
                            }
                            else
                            {
                                int patentepos2=Convert.ToInt32(separacion[1]);//verificacion de que se pueda pasar a entero, si no se puede entonces son letras
                                string patentepos2string=separacion[1];
                                if (miPila.Contains(valor))
                                {
                                    char separador2=' ';
                                    string [] separacion2=nuevovalor.Split(separador2);
                                    bool result3 = separacion2[0].All(Char.IsLetter);
                                    bool result4 = separacion2[0].All(Char.IsUpper);
                                    if(result3==false)
                                    {
                                        mensaje("Introduce 3 letras mayusculas, 1 espacio y 3 numeros");
                                    }
                                    else if(result4==false)
                                    {
                                        mensaje("Introduce 3 letras mayusculas, 1 espacio y 3 numeros");
                                    }
                                    else
                                    {
                                        int datopos=lista.IndexOf(valor);
                                        int patentenuevapos2=Convert.ToInt32(separacion2[1]);
                                        lista[datopos]=nuevovalor;
                                        miPila.Clear();
                                        foreach (string i in lista)
                                        {
                                            miPila.Push(i);
                                        }
                                        lista.Clear();
                                        mensaje("Elemento "+valor+" modificado");
                                    }
                                }
                                else
                                {
                                    lista.Clear();
                                    mensaje("Elemento no encontrado");
                                }
                            }
                        }
                        catch(FormatException)
                        {
                            mensaje("Introduce 3 letras mayusculas, un espacio y 3 numeros");
                        }
                    }
                }
            }
            else
            {
                mensaje("La Pila esta vacia");
            }
        }

        static void buscarpatente(Stack miPila)
        {
            Console.WriteLine("\n>Ingrese patente, ejem:ZSQ 354");
            string valor=Console.ReadLine();
            
            if (valor.Length>7 || valor.Length<7)
            {
                mensaje("Solo patentes de 6 digitos y 1 espacio");
            }
            else
            {
                if (miPila.Count>0)
                {
                    try
                    {
                        char separator=' ';
                        string [] separacion=valor.Split(separator);//es una lista de string
                        bool result = separacion[0].All(Char.IsLetter);//verificacion de que se pueda pasar a letras, si no se puede entonces el string no contiene letras
                        bool result2=separacion[0].All(Char.IsUpper);//verificacion de que sean mayusculas
                        if(result==false)
                        {
                            mensaje("Introduce 3 letras mayusculas, un espacio y 3 numeros");
                        }
                        else if(result2==false)
                        {
                            mensaje("Introduce 3 letras mayusculas, un espacio y 3 numeros");
                        }
                        else
                        {
                            int patentepos2=Convert.ToInt32(separacion[1]);
                            if (miPila.Contains(valor))
                            {
                                foreach(string dato in miPila)
                                {
                                    if (dato==valor)
                                    {
                                        Console.WriteLine("    |           |");
                                        Console.WriteLine("    |  {0}  |", dato);
                                        Console.WriteLine("    |___________|");
                                        Enter();
                                    }
                                }
                            }
                            else
                            {
                                mensaje("Valor no encontrado en la pila");
                            }
                        }
                    }
                    catch(FormatException)
                    {
                        mensaje("Introduce 3 letras mayusculas, un espacio y 3 numeros");
                    }
                }
                else
                {
                    mensaje("La pila esta vacia");
                }
            }
        }

        static void Enter()
        {
            Console.WriteLine("Presione Enter para continuar");
            Console.ReadLine();
        }
    }
}