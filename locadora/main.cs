using System;
using System.Globalization;
using System.Threading;
using System.Xml.Serialization;
using System.IO;
public class Program{
  public static void Main(){
    int op=0;
    do{
      try{
       Console.WriteLine("Seja bem-vindo(a) ao sistema da Locadora de Veículos - LG");
      Console.WriteLine();
      op=Menu();
      switch(op){
        case 1:MainVeiculos();break;
        case 2:MainClientes();break;
        case 3:MainLocacao();break;
        case 0:Main();break;
        default: Console.WriteLine("---------------------------------------\nOpção não encontrada!\n----------------------------------------\n");break;
      } 
      }catch(FormatException){
        Console.WriteLine("Digite apenas números");
      }
    }while(op!=0);
  }

  public static int Menu(){
    Console.WriteLine("<---- Menu Principal ---->\n");
    Console.WriteLine("Escolha uma opção:\n");
    Console.WriteLine("1 - Veículos");
    Console.WriteLine("2 - Clientes");
    Console.WriteLine("3 - Alocação");
    Console.WriteLine("0 - Finalizar sistema");
    Console.WriteLine("\n------------------------------");
    Console.Write("\nOpção: ");
    int op= int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static void MainVeiculos(){
    int opveiculo=0;
    do{
      try{
        Console.WriteLine("<---- Menu de Veículos ---->\n");      
      Console.WriteLine();
      opveiculo=SubMenuVeiculo();
      switch(opveiculo){
        case 1:VeiculoInserir();break;
        case 2:VeiculoAtualizar();break;
        case 3:VeiculoListar();break;
        case 4:VeiculoExcluir();break;
        case 0:MainVeiculos();break;
        default: Console.WriteLine("---------------------------------------\nOpção não encontrada!\n----------------------------------------\n");break;
      }
      }catch(FormatException){
        Console.WriteLine("Digite apenas números");
      }
    }while(opveiculo!=0);
  }

  public static int SubMenuVeiculo(){
    Console.WriteLine("Escolha uma opção:\n");
    Console.WriteLine("1 - Inserir Veículos");
    Console.WriteLine("2 - Atualizar Veículos");
    Console.WriteLine("3 - Listar Veículos");
    Console.WriteLine("4 - Excluir Veículos");

    Console.WriteLine("0 - Voltar ao Menu Principal");
    Console.WriteLine("\n------------------------------");
    Console.Write("\nOpção: ");
    int opveiculo = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opveiculo;
  }

  public static void VeiculoInserir(){
    Console.WriteLine("<---- Inserir Veículo ---->\n"); 
    Console.Write("Digite o ID para a identifação do veículo: ");
    int id=int.Parse(Console.ReadLine());
    Console.Write("\nInforme o modelo do veiculo: ");
    string modelo=Console.ReadLine();
    Console.Write("\nInforme a placa do veiculo: ");
    string placa=Console.ReadLine();
    Veiculo obj= new Veiculo(id,modelo,placa);
    Sistema.VeiculoInserir(obj);
    Console.WriteLine("\nVeiculo registrado!");
    Console.WriteLine("\n ------------------------------");
  }
  
  public static void VeiculoAtualizar(){
    VeiculoListar();
    Console.WriteLine("<---- Atualizar dados de um Veículo ----> \n"); 
    Console.Write("Digite o ID do veiculo que será atualizado: ");
    int id=int.Parse(Console.ReadLine());
    Console.Write("\nInsira o novo modelo: ");
    string modelo=Console.ReadLine();
    Console.Write("\nInsira o a nova placa: ");
    string placa=Console.ReadLine();
    Veiculo obj= new Veiculo(id,modelo,placa);
    Sistema.VeiculoAtualizar(obj);
     Console.WriteLine("\n----- Operação realizada com sucesso -----");
  }
  
  public static void VeiculoListar(){
    Console.WriteLine("<---- Lista de veiculos cadastrados ----> \n"); 
    foreach(Veiculo obj in Sistema.VeiculoListar())
       Console.WriteLine(obj);
    Console.WriteLine("\n------------------------------"); 
  }
  
  public static void VeiculoExcluir(){
    VeiculoListar();
    Console.WriteLine("<---- Excluindo um veiculo ---->\n"); 
    Console.Write("Insira o ID do veiculo que será excluído:");
    int id=int.Parse(Console.ReadLine());
    string modelo="";
    string placa="";
    Veiculo obj = new Veiculo(id,modelo,placa);
    Sistema.VeiculoExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");    
  }

  public static void MainClientes(){
    int opcliente=0;
    do{
      try{
        Console.WriteLine("<----  Menu de Clientes ----> \n");
      opcliente=SubMenuCliente();
      switch(opcliente){
        case 1:ClienteInserir();break;
        case 2:ClienteAtualizar();break;
        case 3:ClienteListar();break;
        case 4:ClienteExcluir();break;
        case 0:MainClientes();break;
        default: Console.WriteLine("---------------------------------------\nOpção não encontrada!\n----------------------------------------\n");break;
      }
      }catch(FormatException){
        Console.WriteLine("Digite apenas números!");
      }
    }while(opcliente!=0);
  }

  public static int SubMenuCliente(){

    Console.WriteLine("Escolha uma opção: \n");
    Console.WriteLine("1 - Inserir novo cliente");
    Console.WriteLine("2 - Atualizar dados do cliente");
    Console.WriteLine("3 - Listar clientes");
    Console.WriteLine("4 - Excluir cliente");
    Console.WriteLine("0 - Voltar ao Menu Principal");
    Console.WriteLine("\n------------------------------"); 
    Console.Write("Opção: ");
    int opcliente = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcliente;
  }
  
  public static void ClienteInserir(){
    Console.WriteLine("<---- Novo Cadastro de Cliente ---->\n");   
    Console.Write("Digite o ID para o Cliente: ");
    int idcliente=int.Parse(Console.ReadLine());         
    Console.Write("\nDigite o nome do Cliente: ");
    string nome=Console.ReadLine();
    Console.Write("\nInforme o CPF (somente números): ");
    long cpf=long.Parse(Console.ReadLine());
    Console.Write("\nInforme o email: ");
    string email=Console.ReadLine();
    Cliente obj= new Cliente{IdCliente=idcliente,Nome=nome,Cpf=cpf,Email=email};
    Sistema.ClienteInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");    
  }

  public static void ClienteAtualizar(){
    ClienteListar();
    Console.WriteLine("<---- Atualizar um cliente ---->\n"); 
    Console.Write("Informe o id do cliente que será atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("\nNome: ");
    string nome= Console.ReadLine();
    Console.Write("\nEmail: ");
    string email=Console.ReadLine();
    Console.Write("\nCPF: ");
    int cpf=int.Parse(Console.ReadLine());
    Cliente obj =  new Cliente{IdCliente=id,Nome=nome,Cpf=cpf,Email=email};
    Sistema.ClienteAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");    
  }
  
  public static void ClienteListar(){
    Console.WriteLine("<---- Lista de clientes ativos ---->\n"); 
    foreach(Cliente obj in Sistema.ClienteListar())
       Console.WriteLine(obj);
    Console.WriteLine("------------------------------"); 
  }  
  
  public static void ClienteExcluir(){
    ClienteListar();
    Console.WriteLine("<---- Excluir um cliente ----> \n"); 
    ClienteListar();
    Console.Write("Informe o id do cliente que será excluído: ");
    int id = int.Parse(Console.ReadLine());
    Cliente obj =  new Cliente{IdCliente=id};
    Sistema.ClienteExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----"); 
  }

public static void MainLocacao(){
    int oplocacao=0;
    do{
      try{
      Console.WriteLine("<----  Menu de Locação ----> \n");
      oplocacao=SubMenuLocacao();
      switch(oplocacao){
        case 1:LocadoraInserir();break; 
        case 2:LocadoraAtualizar();break; 
        case 3:LocadoraListar();break; 
        case 4:LocadoraExcluir();break;
        case 5:Sistema.ToXML();break;
        case 6:Sistema.FromXML();
        case 0:MainLocacao();break;
        default: Console.WriteLine("---------------------------------------\nOpção não encontrada!\n----------------------------------------\n");break;
      }
      }catch(FormatException){
        Console.WriteLine("Digite apenas números");
      }
    }while(oplocacao!=0);
  }

  public static int SubMenuLocacao(){
    Console.WriteLine("Escolha uma opção:\n");
    Console.WriteLine("1 - Realizar locação");
    Console.WriteLine("2 - Atualizar locação");
    Console.WriteLine("3 - Listar locação");
    Console.WriteLine("4 - Excluir locação");
    Console.WriteLine("5 - Abrir locações salvar");
    Console.WriteLine("6 - Salvar locações");
    Console.WriteLine("0 - Voltar ao Menu Principal");
    Console.WriteLine("\n------------------------------"); 
    Console.Write("\nOpção: ");
    int oplocacao = int.Parse(Console.ReadLine());
    return oplocacao;
  }

  public static void LocadoraInserir(){
    Console.WriteLine("<---- Novo Cadastro de Locação ---->\n"); 
    Console.Write("Escolha um ID para esta locação: ");
    int idloc=int.Parse(Console.ReadLine());
    Console.WriteLine("\nPara seleção de veículos visualize os automovéis disponiveis:\n");
    VeiculoListar();
    Console.Write("\nID do veículo que deseja alocar:");
    int idveiculo=int.Parse(Console.ReadLine());
    ClienteListar();
    Console.Write("\nID do cliente que deseja alocar:");    
    int idcliente=int.Parse(Console.ReadLine());
    Locadora obj =  new Locadora{IdLocacao=idloc,IdCliente=idcliente,IdVeiculo=idveiculo};
    Sistema.LocadoraInserir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  
  public static void LocadoraAtualizar(){
    LocadoraListar();
    Console.WriteLine("<---- Atualizar uma Locação ---->\n"); 
    LocadoraListar();
    Console.Write("\nInforme o ID da locação: ");
    int id = int.Parse(Console.ReadLine());
    VeiculoListar();
    Console.Write("\nInsira o ID de um dos veiculos acima: ");
    int idveiculo=int.Parse(Console.ReadLine());
    ClienteListar();
    Console.Write("\nInsira o ID de um dos clientes acima: ");
    int idcliente = int.Parse(Console.ReadLine());
    Locadora obj =  new Locadora{IdLocacao=id,IdCliente=idcliente,IdVeiculo=idveiculo};
    Sistema.LocadoraAtualizar(obj);
    Console.WriteLine("\n----- Operação realizada com sucesso -----");
  }

  public static void LocadoraListar(){
    Console.WriteLine("<---- Lista de Locações ---->\n");     
    foreach(Locadora obj in Sistema.LocadoraListar()) { 
      Veiculo v = Sistema.VeiculoListar(obj.IdVeiculo);
      Cliente c = Sistema.ClienteListar(obj.IdCliente);
      Console.WriteLine($"\n{c.Nome}      {c.Cpf}\n{c.Email}\n------------------------------\n{v.GetModelo()}      {v.GetPlaca()} ");
    Console.WriteLine("\n------------------------------"); 
    }
  }
  public static void LocadoraExcluir(){
    LocadoraListar();
    Console.WriteLine("<---- Excluir uma Locação ---->\n");
    LocadoraListar();
    Console.Write("Informe o id da locação que será excluída: ");
    int id = int.Parse(Console.ReadLine());
    Locadora obj =  new Locadora{IdLocacao=id};
    Sistema.LocadoraExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----"); 
  }
}