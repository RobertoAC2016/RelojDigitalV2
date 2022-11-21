//      Vamos ahora a desarrollar no solo la impresion de del tiempo en pantalla
//      Sino q ahora lo haremos en grande, veremos como obtener un resultado como el siguiente
//        ███      ████████               ████████   ████████               ████████   ████████
//       ████     ██      ██     ████    ██      ██ ██      ██     ████    ██      ██ ██      ██
//      ██ ██             ██     ████            ██ ██      ██     ████            ██         ██
//         ██     ██████████             ██████████ ██████████             ██████████ █████████
//         ██     ██             ████    ██                 ██     ████    ██                 ██
//         ██     ██      ██     ████    ██      ██         ██     ████    ██      ██ ██      ██
//     ██████████  ████████               ████████   ████████               ████████   ████████
//      Ahora usaremos un tmer para actualizar la hora y los digitos

using System.Timers;

System.Timers.Timer reloj = new System.Timers.Timer(1000);//cada segundo realizara una tarea

String simbols = "░▒▓¤█▄▀";
string car = "";
//usaremos la clase random para seleccionar los colores aleatoriamente
Random rnd = new Random();
List<ConsoleColor> colores = new List<ConsoleColor>
{
    ConsoleColor.White,
    ConsoleColor.Red,
    ConsoleColor.DarkRed,
    ConsoleColor.Blue,
    ConsoleColor.DarkBlue,
    ConsoleColor.Yellow,
    ConsoleColor.DarkYellow,
    ConsoleColor.Gray,
    ConsoleColor.DarkGray,
    ConsoleColor.Magenta,
    ConsoleColor.DarkMagenta,
    ConsoleColor.Green,
    ConsoleColor.DarkGreen,
};
//hagamos el reloj mas tenue
void start()
{
    car = $"{simbols[0]}";

    reloj.Elapsed += tarea_cada_vez;//este es un evento de la clase Timer
    reloj.Start();

    Console.Read();
}
void tarea_cada_vez(object? sender, ElapsedEventArgs e)
{
    Console.Clear();
    //vamos a darle espacios desde la parte superios para q sea vea mejor
    for (int i = 0; i < 8; i++) Console.WriteLine();
    //esta vez mandamos a llamar a pintar reloj
    pintar_reloj();
    //usaremos el gc collec para reciclar memoria
    GC.Collect();
    //veamos como se ve
}
void pintar_reloj()
{
    var tiempo = DateTime.Now;
    //obtenemos la hora, minuto y segundo por separado
    var la_hora = tiempo.Hour > 10 ? $"{tiempo.Hour}" : $"0{tiempo.Hour}";
    var minuto = tiempo.Minute > 10 ? $"{tiempo.Minute}" : $"0{tiempo.Minute}";
    var segundo = tiempo.Second > 10 ? $"{tiempo.Second}" : $"0{tiempo.Second}";
    //vamos a imprimirlo
    //Console.WriteLine($"        {la_hora}:{minuto}:{segundo}");
    //ahora tenemos q asegurarnos que cada fraccion del tiempo sea de 2 digitos, tenemos 6 digitos
    var digito1 = $"{get_digitos(la_hora[0])}";
    var digito2 = $"{get_digitos(la_hora[1])}";
    var digito3 = $"{get_digitos(minuto[0])}";
    var digito4 = $"{get_digitos(minuto[1])}";
    var digito5 = $"{get_digitos(segundo[0])}";
    var digito6 = $"{get_digitos(segundo[1])}";

    //cambiaremos el color al momento de imprimir los digitos
    Console.ForegroundColor = colores[rnd.Next(colores.Count)];
    int columnas = 12;
    for (int i = 0; i < 7; i++)//filas
    {
        var cad = "";
        cad += get_left_space(i);
        cad += digito1.Substring(columnas - 12, 12);
        cad += digito2.Substring(columnas - 12, 12);
        cad += get_dots(i);
        cad += digito3.Substring(columnas - 12, 12);
        cad += digito4.Substring(columnas - 12, 12);
        cad += get_dots(i);
        cad += digito5.Substring(columnas - 12, 12);
        cad += digito6.Substring(columnas - 12, 12);
        Console.WriteLine(cad.Replace("-", car));
        columnas = columnas + 12;
    }
    //restauraremos el color al terminar de imprimir el reloj
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("                            Developed by keepteacher@gmail.com coding master");
}
string get_dots(int opc)
{
    switch (opc)
    {
        case 0: 
            return "            "; break;//dejaremos 12 espacios representando las columnas
        case 1:
            return "    ----    "; break;
        case 2:
            return "    ----    "; break;
        case 3:
            return "            "; break;
        case 4:
            return "    ----    "; break;
        case 5:
            return "    ----    "; break;
        default:
            return "            "; break;
    }
}
string get_left_space(int opc)
{
    switch (opc)
    {
        case 0:
            return "            "; break;//dejaremos 12 espacios representando las columnas
        case 1:
            return "            "; break;
        case 2:
            return "            "; break;
        case 3:
            return "            "; break;
        case 4:
            return "            "; break;
        case 5:
            return "            "; break;
        default:
            return "            "; break;
    }
}
object get_digitos(char car)
{
    switch (car)
    {
        case '1':   //usaremos 12 caracteres que representaran las columnas y 7 filas
            return "    ---     " + //  Fila 1
                   "   ----     " + //  Fila 2
                   "  -- --     " + //  Fila 3
                   "     --     " + //  Fila 4
                   "     --     " + //  Fila 5
                   "     --     " + //  Fila 6
                   " ---------- ";  //  Fila 7
            break;  //haremos esto para los otros digitos             
        case '2':
            return "  --------  " +
                   " --      -- " +
                   "         -- " +
                   " ---------- " +
                   " --         " +
                   " --      -- " +
                   "  --------  ";
            break;
        case '3':
            return "  --------  " +
                   " --      -- " +
                   "         -- " +
                   " ---------  " +
                   "         -- " +
                   " --      -- " +
                   "  --------  ";
            break;
        case '4':
            return " --      -- " +
                   " --      -- " +
                   " --      -- " +
                   " ---------- " +
                   "         -- " +
                   "         -- " +
                   "         -- ";
            break;
        case '5':
            return "  --------- " +
                   " --      -- " +
                   " --         " +
                   "  --------- " +
                   "         -- " +
                   " --      -- " +
                   "  --------  ";
            break;
        case '6':
            return "  --------  " +
                   " --      -- " +
                   " --         " +
                   " ---------- " +
                   " --      -- " +
                   " --      -- " +
                   "  --------  ";
            break;
        case '7':
            return " ---------- " +
                   " --      -- " +
                   "         -- " +
                   "         -- " +
                   "         -- " +
                   "         -- " +
                   "         -- ";
            break;
        case '8':
            return "  --------  " +
                   " --      -- " +
                   " --      -- " +
                   " ---------- " +
                   " --      -- " +
                   " --      -- " +
                   "  --------  ";
            break;
        case '9':
            return "  --------  " +
                   " --      -- " +
                   " --      -- " +
                   " ---------- " +
                   "         -- " +
                   "         -- " +
                   "  --------  ";
            break;
        default:
            return "  --------  " +
                   " --      -- " +
                   " --      -- " +
                   " --      -- " +
                   " --      -- " +
                   " --      -- " +
                   "  --------  ";
            break;
    }
}
//ahora solo cambiemos de colores
start();