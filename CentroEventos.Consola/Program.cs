using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

    Console.WriteLine("Hello, World!");
    Console.WriteLine("asdasddasd");
    Console.WriteLine("que f");
    int i=10;
    Console.WriteLine(" la variable i vale: "+i);


    try{
        ValidadorPersona validador= new ValidadorPersona();
        Persona persona=new Persona(1,"dni","nombre","apellido","asd@gmail.com","221");
        validador.Validar(persona);
        Console.WriteLine(" la persona es valida");
    }
    catch(ValidacionException ex){
        Console.WriteLine($"{ex.Message}"); 
    }



