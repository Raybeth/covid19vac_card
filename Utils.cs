class Utils
{
    public static string LeerString(string mensaje)
    {
        Console.Write(mensaje);
        return Console.ReadLine() ?? "";
    }


    public static void MostrarMensaje(string mensaje, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(mensaje);
        Console.ResetColor();
        Console.ReadKey();
    }

    public static void MostrarMensajeError(string mensaje)
    {
        MostrarMensaje(mensaje, ConsoleColor.Red);

    }

    public static void Pausa()
    {
        Utils.MostrarMensaje("Presione una tecla para continuar...", ConsoleColor.Blue);
        Console.ReadLine();
    }

}

