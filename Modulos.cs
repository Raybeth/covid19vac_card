using Microsoft.EntityFrameworkCore;
class Modulos
{
    public static void Configuracion()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine(@"
       
   __,_,
  [_|_/ 
   //
 _//    __
(_|)   |@@|
 \ \__ \--/ __
  \o__|----|  |   __
      \ }{ /\ )_ / _\
      /\__/\ \__O (__
     (--/\--)    \__/
     _)(  )(_
    `---''---`

    CONFIGURATION
p- Provincias
v- Vacunas
r- Regresar
        ");
            var opcion = Utils.LeerString("Ingrese una opcion: ");
            switch (opcion.ToLower())
            {
                case "p":
                    Console.WriteLine("Provincias: ");
                    Modulos.Conf_Provincias();
                    break;
                case "v":
                    Console.WriteLine("Vacunas: ");
                    Modulos.Conf_Vacunas();
                    break;
                case "r":
                    continuar = false;
                    break;
                default:
                    Utils.MostrarMensajeError("Opcion no valida");
                    Utils.Pausa();
                    break;
            }


        }

    }
    public static void Conf_Provincias()
    {
        var db = new CovidContext();
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine(@"
        Gestion de provincias

        1. Agregar provincia
        2. Editar provincia
        3. Eliminar provincia
        r. Regresar
        ");
            var opcion = Utils.LeerString("Ingrese una opcion: ");
            switch (opcion.ToLower())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Agregar provincia");
                    Utils.MostrarMensaje("Vamos a agregar una provincia...", ConsoleColor.Blue);
                    var p = new Provincia();
                    p.Nombre = Utils.LeerString("Ingrese el nombre de la provincia: ");

                    db.Provincias.Add(p);
                    db.SaveChanges();

                    Utils.MostrarMensaje("Provincia agregada!", ConsoleColor.Blue);
                    Utils.Pausa();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Editar provincia");
                    Console.WriteLine("Vamos a editar una provincia... ");

                    List<Provincia> provincias = db.Provincias.ToList();
                    foreach (var prov in provincias)
                    {
                        Console.WriteLine($"{prov.Id} - {prov.Nombre}");
                    }
                    Console.WriteLine("Ingrese el id de la provincia que desea editar: ");
                    var editar = db.Provincias.Find(int.Parse(Console.ReadLine() ?? ""));
                    if (editar == null)
                    {
                        Utils.MostrarMensajeError("No se encontró la provincia");
                        Utils.Pausa();
                    }
                    else
                    {
                        Console.WriteLine($"Editar el nombre de la provincia: ({editar.Nombre}) ");
                        editar.Nombre = Console.ReadLine() ?? "";
                        db.SaveChanges();
                        Utils.MostrarMensaje("Provincia editada!", ConsoleColor.Blue);
                    }
                    Utils.Pausa();

                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Eliminar provincia");
                    List<Provincia> provincia2 = db.Provincias.ToList();
                    foreach (var prov in provincia2)
                    {
                        Console.WriteLine($"{prov.Id} - {prov.Nombre}");
                    }
                    Console.WriteLine("Ingrese el id de la provincia que desea eliminar: ");
                    var eliminar = db.Provincias.Find(int.Parse(Console.ReadLine() ?? ""));
                    if (eliminar == null)
                    {
                        Utils.MostrarMensajeError("No se encontró la provincia");
                    }
                    else
                    {
                        db.Provincias.Remove(eliminar);
                        db.SaveChanges();
                        Utils.MostrarMensaje("Provincia eliminada!", ConsoleColor.Blue);
                    }
                    Utils.Pausa();
                    break;

                case "r":
                    continuar = false;
                    break;
                default:
                    Utils.MostrarMensajeError("Opcion no valida");
                    Utils.Pausa();
                    break;
            }
        }

    }
    public static void Conf_Vacunas()
    {
        var db = new CovidContext();
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine(@"
            
            Gestion de Vacunas

            1. Agregar Vacuna
            2. Editar Vacuna
            3. Eliminar Vacuna
            r- Regresar
            
            ");
            var opcion = Utils.LeerString("Ingrese una opcion: ");
            switch (opcion.ToLower())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Agregar Vacuna");
                    var v = new Vacuna();
                    v.Nombre = Utils.LeerString("Ingrese el nombre de la vacuna: ");
                    db.Vacunas.Add(v);
                    db.SaveChanges();
                    Utils.MostrarMensaje("Vacuna agregada!", ConsoleColor.Blue);

                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Editar Vacuna");
                    Console.WriteLine("Vamos a editar una vacuna...");

                    List<Vacuna> vacunas = db.Vacunas.ToList();
                    foreach (var vac in vacunas)
                    {
                        Console.WriteLine($"{vac.Id} - {vac.Nombre}");
                    }
                    Console.WriteLine("Ingrese el id de la vacuna que desea editar: ");
                    var editar = db.Vacunas.Find(int.Parse(Console.ReadLine() ?? ""));
                    if (editar == null)
                    {
                        Utils.MostrarMensajeError("No se encontró la vacuna");
                    }
                    else
                    {
                        Console.WriteLine($"Editar el nombre de la vacuna: ({editar.Nombre}) ");
                        editar.Nombre = Console.ReadLine() ?? "";
                        db.SaveChanges();
                        Utils.MostrarMensaje("Vacuna editada!", ConsoleColor.Blue);
                    }
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Eliminar vacuna");
                    List<Vacuna> vacuna2 = db.Vacunas.ToList();
                    foreach (var vac in vacuna2)
                    {
                        Console.WriteLine($"{vac.Id} - {vac.Nombre}");
                    }
                    Console.WriteLine("Ingrese el id de la vacuna que desea eliminar: ");
                    var eliminar = db.Vacunas.Find(int.Parse(Console.ReadLine() ?? ""));
                    if (eliminar == null)
                    {
                        Utils.MostrarMensajeError("No se encontró la vacuna");
                    }
                    else
                    {
                        db.Vacunas.Remove(eliminar);
                        db.SaveChanges();
                        Utils.MostrarMensaje("Vacuna eliminada!", ConsoleColor.Blue);
                    }
                    break;

                case "r":
                    continuar = false;
                    break;

                default:
                    Utils.MostrarMensajeError("Opcion no valida");
                    Utils.Pausa();
                    break;
            }
        }
    }
    public static void Registrar_Vacunado()
    {
        var db = new CovidContext();
        Console.Clear();
        Console.WriteLine("Registrar Vacunado");
        var p = new Persona();
        var proceso = new Proceso();

        var cedula = Utils.LeerString("Ingrese la cedula sin guiones: ");

        p = db.Personas.Where(x => x.Cedula == cedula).FirstOrDefault();

        //Si la perona no exite hace este proceso
        if (p == null)
        {
            p = new Persona();
            p.Cedula = cedula;
            var personaCedula = new Persona_Cedula();
            personaCedula.ok = false;
            try
            {
                var url = "https://api.adamix.net/apec/cedula/" + cedula;
                var client = new HttpClient();
                var response = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
                personaCedula = Newtonsoft.Json.JsonConvert.DeserializeObject<Persona_Cedula>(response);
            }
            catch (Exception) { }

            if (personaCedula.ok)
            {
                p.Nombre = personaCedula.Nombres;
                p.Apellido = $"{personaCedula.Apellido1} {personaCedula.Apellido2}";
            }
            else
            {
                p.Nombre = Utils.LeerString("Ingrese el nombre: ");
                p.Apellido = Utils.LeerString("Ingrese el apellido: ");
            }
            p.Telefono = Utils.LeerString("Ingrse el telefono: ");
            db.Personas.Add(p);
        }
        proceso.Persona = p;
        proceso.Fecha = DateTime.Now;

        var listadoVacunas = db.Vacunas.ToList();
        foreach (var vac in listadoVacunas)
        {
            Console.WriteLine($"{vac.Id} - {vac.Nombre}");
        }

        while (proceso.Vacuna == null)
        {
            Console.WriteLine("Ingrese el id de la vacuna: ");
            var vacuna = db.Vacunas.Find(int.Parse(Console.ReadLine()));
            if (vacuna == null)
            {
                Utils.MostrarMensajeError("No se encontró la vacuna.");
            }
            else
            {
                proceso.Vacuna = vacuna;
            }
        }
        var listadoProvincias = db.Provincias.ToList();
        foreach (var prov in listadoProvincias)
        {
            Console.WriteLine($"{prov.Id} - {prov.Nombre}");
        }
        while (proceso.Provincia == null)
        {
            Console.WriteLine("Ingrese el id de la provincias: ");
            var provincia = db.Provincias.Find(int.Parse(Console.ReadLine()));
            if (provincia == null)
            {
                Utils.MostrarMensajeError("No se encontró la provincia.");
            }
            else
            {
                proceso.Provincia = provincia;
            }
        }
        db.Procesos.Add(proceso);
        db.SaveChanges();
        Utils.MostrarMensaje("Vacunado registrado!", ConsoleColor.Blue);

    }

    public static void Exportar()
    {
        var db = new CovidContext();
        Console.Clear();
        Console.WriteLine("Vamos a exportar tarjeta de vacunacion :D ");

        Persona persona = null;
        while (persona == null)
        {
            var cedula = Utils.LeerString("Ingrese la cedula sin guines o x para ver un listado de las personas: ");
            if (cedula.ToLower().Trim() == "x")
            {
                var listadoPersonas = db.Personas.ToList();
                foreach (var p in listadoPersonas)
                {
                    Console.WriteLine($"{p.Id}) {p.Cedula} {p.Nombre} {p.Apellido}");
                }
                cedula = Utils.LeerString("Digite el id de la persona: ");
                persona = db.Personas.Find(int.Parse(cedula));
            }
            else
            {
                persona = db.Personas.Where(x => x.Cedula == cedula).FirstOrDefault();
            }
        }
        var listadoProcesos = db.Procesos.Where(x => x.Persona.Id == persona.Id)
        .Include(x => x.Vacuna).Include(x => x.Provincia).ToList();

        Console.WriteLine($"{persona.Nombre} - {persona.Apellido}");
        var detalle = "";
        foreach (var proceso in listadoProcesos)
        {
            Console.WriteLine($"{proceso.Id} {proceso.Vacuna.Nombre} - {proceso.Provincia.Nombre} {proceso.Fecha.ToShortDateString()}");
            detalle += @$"
                <tr>
                    <td>{proceso.Fecha.ToShortDateString()}</td>
                    <td>{proceso.Vacuna.Nombre}</td>
                    <td>{proceso.Provincia.Nombre}</td>
                
                
                </tr>
            ";
        }


        var html = @$"
        <html>
            <head>
                <title>Tarjeta de Vacunacion</title>


                <!-- Compiled and minified CSS -->
                <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css'>
            </head>
            <body>
                <div class='container'>
                <h1>{persona.Nombre} {persona.Apellido}</h1>
                <img style='max-width: 200px;' src='https://api.adamix.net/apec/foto2/{persona.Cedula}' alt='logo' class='logo'>
                <h5>Cedula: {persona.Cedula}</h5>
                <h5>Telefono: {persona.Telefono}</h5>
                <h4 style='font-weight:bold;'> Procesos aplicados</h4>
                <table class='table'>
                    <thead>
                    <tr>
                        <th>Fecha</th>
                        <th>Vacuna</th>
                        <th>Provincia</th>
                        
                    </tr>
                    </thead>
                    {detalle}
                </table>
                </div>

            </body>

        </html>
    
    ";
        System.IO.File.WriteAllText("tarjeta.html", html);
        var uri = "tarjeta.html";
        var psi = new System.Diagnostics.ProcessStartInfo();
        psi.UseShellExecute = true;
        psi.FileName = uri;
        System.Diagnostics.Process.Start(psi);
    }
}