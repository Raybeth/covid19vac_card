/*Tarea 6
Nombre Lisbeth Jimenez
Matricula 2022-0790

Profesor dejenos descansar!!!!!!!

*/

bool continuar = true;
while (continuar)
{
    Console.Clear();
    Console.WriteLine(@"

REGISTRO DE VACUNADOS
     _____
    [IIIII]
     )   (
    /     \
   /       \
   |`-...-'|
   |covid19|
 _ |`-...-'j    _
(\)`-.___.(I) _(/)
  (I)  (/)(I)(\)
     (I)        hjw

1. Registrar Vacunados
2. Exportar Tarjeta de vacunacion
3. Configuracion
x. Salir
    
    ");

    var opcion = Utils.LeerString("Ingrese una opcion: ");
    switch (opcion.ToLower())
    {
        case "1":
            Console.WriteLine("Registrar Vacunados");
            Modulos.Registrar_Vacunado();
            break;
        case "2":
            Console.WriteLine("Exportar Tarjeta de vacunacion");
            Modulos.Exportar();
            break;
        case "3":
            Console.WriteLine("Configuracion");
            Modulos.Configuracion();
            break;
        case "x":
            continuar = false;
            Utils.MostrarMensaje("Gracias por ayudar a salvar el mundo el mundo.", ConsoleColor.Green);
            break;
        default:
            Utils.MostrarMensajeError("Opcion no valida");
            break;
    }
}