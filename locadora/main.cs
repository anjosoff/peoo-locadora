using System;

public class Program{
  public static void Main(){
    Console.WriteLine("Bem vindo ao sistema da LOCADORA LG");
    Veiculo v1= new Veiculo("corsa","1ABCD");
    Veiculo v2= new Veiculo("camaro","2DCBA");
    Locadora l1=new Locadora("LG");
    Locadora l2=new Locadora("CONCORRENTE");
    Console.WriteLine(v1);
    Console.WriteLine(v2);
    Console.WriteLine(l1);
    Console.WriteLine(l2);
  }
}