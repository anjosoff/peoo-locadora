using System;

public class Program{
  public static void Main(){
    Console.WriteLine("Bem vindo ao sistema da LOCADORA DE VEICULOS LG");
    Console.WriteLine();
    int op=0;
    do{
      op=Menu();
      switch(op){
        case 1:VeiculoInserir();break;
        case 2:VeiculoListar();break;
      }
    }while(op!=0);
    
  }
  public static int Menu(){
    Console.WriteLine(">>>> Escolha uma opção <<<<");
    Console.WriteLine("1 - Inserir novo veiculo");
    Console.WriteLine("2 - Listar veiculo cadastrados");
    Console.WriteLine("0 - Finalizar o sistema");
    Console.WriteLine("---------------------------------------");
    Console.Write("Opção:");
    int op= int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static void VeiculoInserir(){
    Console.WriteLine(">>> Inserir um novo veiculo <<<");
      // dados do veiculo
      Console.WriteLine("Informe o Modelo do veiculo:");
    string modelo=Console.ReadLine();
     Console.WriteLine("Informe o Placa do veiculo:");
    string placa=Console.ReadLine();
    //instanciar a classe
    Veiculo obj= new Veiculo(modelo,placa);
    //inserir no sistema
    Sistema.VeiculoInserir(obj);
    Console.WriteLine("Veiculo Registrado!");
    Console.WriteLine("----------------------------------------");
    
  }
  public static void VeiculoListar(){
    Console.WriteLine(">>> Lista de veiculos cadastrados <<<");
    foreach(Veiculo obj in Sistema.VeiculoListar())
       Console.WriteLine(obj);
    Console.WriteLine("----------------------------------------");
  }
}